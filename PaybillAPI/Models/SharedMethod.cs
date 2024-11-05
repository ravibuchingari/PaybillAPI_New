using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace PaybillAPI.Models
{
    public class SharedMethod
    {
        internal static void ThrowError(DbUpdateException ex)
        {
            if (ex.InnerException is MySqlException sqlExp)
            {
                throw sqlExp.Number switch
                {
                    1451 => new Exception(string.Format(AppConstants.SQL_DELETE_REFERENCE_MESSAGE, "item")),
                    1452 => new Exception("Cannot add or update a child row: a foreign key constraint fails"),
                    2627 => new Exception("Unique constraint error"),
                    547 => new Exception("Constraint check violation"),
                    2601 => new Exception("Duplicated key row error/Constraint violation exception"),
                    1062 => new Exception(ex.InnerException.Message.Split("for")[0].Trim()),
                    _ => new Exception(sqlExp.Message),
                };
            }
            throw new Exception(ex.Message);
        }

        internal static string GenerateUniqueID() => Guid.NewGuid().ToString("N");

        internal static DataTable ConvertToDataTable<T>(IList<T> data, string[] selectedProperties)
        {
            DataTable dataTable = new();
            if (data == null || data.Count == 0) return dataTable;

            AddColumns(dataTable, typeof(T), selectedProperties);

            foreach (var item in data)
            {
                DataRow row = dataTable.NewRow();
                FillRow(row, item!, selectedProperties);
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private static void AddColumns(DataTable dataTable, Type type, string[] selectedProperties)
        {
            PropertyDescriptorCollection? selectedPropertyDescriptor;
            PropertyDescriptorCollection propertyDescriptor = TypeDescriptor.GetProperties(type);

            if (selectedProperties.Length > 0)
            {
                var filteredProps = propertyDescriptor.Cast<PropertyDescriptor>()
                                                       .Where(prop => selectedProperties.Contains(prop.Name))
                                                       .ToArray();
                selectedPropertyDescriptor = new PropertyDescriptorCollection(filteredProps);
            }
            else
            {
                selectedPropertyDescriptor = propertyDescriptor;
            }

            if (selectedPropertyDescriptor == null) return;


            foreach (PropertyDescriptor prop in selectedPropertyDescriptor)
            {

                if (!prop.PropertyType.IsClass || prop.PropertyType == typeof(string))
                {
                    dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                else if (typeof(IEnumerable<>).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
                {
                    // Handle lists, collections, etc.
                }
                else
                {
                    AddColumns(dataTable, prop.PropertyType, selectedProperties);
                }
            }
        }

        private static void FillRow(DataRow row, object obj, string[] selectedProperties)
        {
            PropertyDescriptorCollection? selectedPropertyDescriptor;
            PropertyDescriptorCollection propertyDescriptor = TypeDescriptor.GetProperties(obj.GetType());

            if (selectedProperties.Length > 0)
            {
                var filteredProps = propertyDescriptor.Cast<PropertyDescriptor>()
                                                       .Where(prop => selectedProperties.Contains(prop.Name))
                                                       .ToArray();
                selectedPropertyDescriptor = new PropertyDescriptorCollection(filteredProps);
            }
            else
            {
                selectedPropertyDescriptor = propertyDescriptor;
            }

            if (selectedPropertyDescriptor == null) return;


            foreach (PropertyDescriptor prop in selectedPropertyDescriptor)
            {
                if (!prop.PropertyType.IsClass || prop.PropertyType == typeof(string))
                {
                    row[prop.Name] = prop.GetValue(obj) ?? DBNull.Value;
                }
                else if (typeof(IEnumerable<>).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
                {
                    // Handle lists, collections, etc.
                }
                else
                {
                    if (prop.GetValue(obj) != null)
                        FillRow(row, prop.GetValue(obj)!, selectedProperties);
                }
            }
        }

        internal static string GenerateExcel(DataTable dataTable, string destinationDir, string title, string fileName = "")
        {
            if (!Directory.Exists(destinationDir)) Directory.CreateDirectory(destinationDir);

            title = title.Trim();
            if (title.Length > 30)
                title = title[..30];
            if (int.TryParse(title[..1], out _))
                title = "_" + title;

            int columns = dataTable.Columns.Count;
            fileName = Path.Combine(destinationDir, $"{fileName}_{GenerateUniqueID()}.xlsx");
            using (XLWorkbook wb = new())
            {
                IXLWorksheet ws = wb.Worksheets.Add(dataTable, title);
                IXLRange range = ws.Range(ws.Cell(1, 1).Address, ws.Cell(1, columns).Address);
                ws.Tables.FirstOrDefault()!.ShowAutoFilter = false;
                ws.Tables.FirstOrDefault()!.Theme = XLTableTheme.None;
                range.Style.Font.Bold = true;
                range.Style.Font.FontColor = XLColor.White;
                range.Style.Fill.BackgroundColor = XLColor.DarkOrange;
                ws.Columns(1, columns).AdjustToContents();
                using FileStream stream = new(fileName, FileMode.Create);
                wb.SaveAs(stream);
            }
            return fileName;
        }
    }
}
