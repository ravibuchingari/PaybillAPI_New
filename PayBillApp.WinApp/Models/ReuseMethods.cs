﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace PayBillApp.WinApp.Models
{
    internal class ReuseMethods
    {
        internal static void SetFormBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            using GraphicsPath graphicsPath = GetRoundedPath(form.ClientRectangle, radius);
            using Pen penBorder = new(borderColor, borderSize);
            using Matrix transform = new();
            graph.SmoothingMode = SmoothingMode.AntiAlias;
            form.Region = new Region(graphicsPath);
            if (borderSize > 0)
            {
                Rectangle rect = form.ClientRectangle;
                float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                float scaleY = 1.0F - ((borderSize + 1) / rect.Height);

                transform.Scale(scaleX, scaleY);
                transform.Translate(borderSize / 1.6F, borderSize / 1.6F);
                graph.Transform = transform;
                graph.DrawPath(penBorder, graphicsPath);
            }
        }

        private static GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            float curveSize = radius * 2F;
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            graphicsPath.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            graphicsPath.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            graphicsPath.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        internal static void SerializeApplicationVariables(bool isBarcodeScanOnly)
        {
            ApplicationVariables variables = new()
            {
                BarcodeScanOnly = isBarcodeScanOnly
            };
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.data");
            using Stream stream = File.OpenWrite(fileName);
            BinaryFormatter binaryFormatter = new();
#pragma warning disable SYSLIB0011
            binaryFormatter.Serialize(stream, variables);
#pragma warning restore SYSLIB0011
            stream.Flush();
        }
        internal static ApplicationVariables DeserializeApplicationVariables()
        {
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.data");
            if (File.Exists(fileName))
            {
                using Stream stream = File.Open(fileName, FileMode.Open);
                BinaryFormatter binaryFormatter = new();
#pragma warning disable SYSLIB0011
                ApplicationVariables applicationVariables = (ApplicationVariables)binaryFormatter.Deserialize(stream);
#pragma warning restore SYSLIB0011
                return applicationVariables;
            }
            else
            {
                return new ApplicationVariables()
                {
                    BarcodeScanOnly = false
                };
            }
        }
    }
}