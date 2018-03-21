﻿using Microsoft.CodeAnalysis;
using System.IO;
using Microsoft.Build.Evaluation;
using System;
using System.Reflection;


foreach (Document document in Project.Analysis.Documents)
{
    if (document.Name == "About.xaml.cs")
    {
        var xamlPath = Path.Combine(Path.GetDirectoryName(document.FilePath), "About.xaml");
        var csprojPath = Path.Combine(Path.GetDirectoryName(document.FilePath), "Frame.csproj");
        var text = File.ReadAllText(xamlPath);
        var lines = File.ReadAllLines(xamlPath);
        var csprojText = File.ReadAllLines(csprojPath);

        foreach (var line in csprojText)
        {
            if(line.Contains("AutoUpdater.NET, "))
            {
                var oldVersionNumber = string.Empty;
                foreach(var xamlLine in lines)
                {
                    if (xamlLine.Contains("Autoupdater.NET.Official("))
                    {
                        oldVersionNumber = xamlLine.Split('(')[1].Split(')')[0];
                    }
                }
                text = text.Replace(string.Format("Autoupdater.NET.Official({0}) by RBSoft", oldVersionNumber), string.Format("Autoupdater.NET.Official({0}) by RBSoft", line.Split('=')[2].Split(',')[0]));
            }
            else if (line.Contains("Cyotek.Windows.Forms.ImageBox, "))
            {
                var oldVersionNumber = string.Empty;
                foreach (var xamlLine in lines)
                {
                    if (xamlLine.Contains("CyotekImageBox("))
                    {
                        oldVersionNumber = xamlLine.Split('(')[1].Split(')')[0];
                    }
                }
                text = text.Replace(string.Format("CyotekImageBox({0}) by Cyotek", oldVersionNumber), string.Format("CyotekImageBox({0}) by Cyotek", line.Split('=')[2].Split(',')[0]));
            }
            else if (line.Contains("Magick.NET-Q16-AnyCPU, "))
            {
                var oldVersionNumber = string.Empty;
                foreach (var xamlLine in lines)
                {
                    if (xamlLine.Contains("Magick.NET("))
                    {
                        oldVersionNumber = xamlLine.Split('(')[1].Split(')')[0];
                    }
                }
                text = text.Replace(string.Format("Magick.NET({0}) by Dirk Lemstra", oldVersionNumber), string.Format("Magick.NET({0}) by Dirk Lemstra", line.Split('=')[2].Split(',')[0]));
            }
            else if (line.Contains("Xceed.Wpf.Toolkit, "))
            {
                var oldVersionNumber = string.Empty;
                foreach (var xamlLine in lines)
                {
                    if (xamlLine.Contains("Extended.Wpf.Toolkit("))
                    {
                        oldVersionNumber = xamlLine.Split('(')[1].Split(')')[0];
                    }
                }
                text = text.Replace(string.Format("Extended.Wpf.Toolkit({0}) by Xceed", oldVersionNumber), string.Format("Extended.Wpf.Toolkit({0}) by Xceed", line.Split('=')[2].Split(',')[0]));
            }
            else if (line.Contains("Dragablz, "))
            {
              var oldVersionNumber = string.Empty;
              foreach (var xamlLine in lines)
              {
                if (xamlLine.Contains("Dragablz("))
                {
                  oldVersionNumber = xamlLine.Split('(')[1].Split(')')[0];
                }
              }
              text = text.Replace(string.Format("Dragablz({0}) by James Willock", oldVersionNumber), string.Format("Dragablz({0}) by James Willock", line.Split('=')[2].Split(',')[0]));
            }
    }
        File.WriteAllText(xamlPath, text);
    }
}