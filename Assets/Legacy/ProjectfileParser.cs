using System.Collections.Generic;
using System.IO;
using FileHandling.FileDialog;
using Legacy.Playing.Elements;
using Misc;

namespace Legacy
{
    public class ProjectfileParser : Singleton<ProjectfileParser>
    {
        public string filePath;

        public bool HasValidPath => File.Exists(filePath ?? "");

        public void SelectPath()
        {
            var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", "txt", false);
            if (paths != null && paths.Length > 0)
            {
                filePath = paths[0];
            }
        }

        public void StoreAll(bool overwrite = false)
        {
            if(!overwrite) SelectPath();
            while (!HasValidPath)
            {
                SelectPath();
            }

            var playables = FindObjectsOfType<PlayElement>();
            var lines = new List<string>();
            foreach (var playable in playables)
            {
                var str = playable.GetString();
                if(str != null)
                    lines.Add(str);
            }
            File.WriteAllLines(filePath, lines.ToArray());
        }

        public void LoadAll()
        {
            do
            {
                SelectPath();
            } while (!HasValidPath);

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var element = PlayElement.Parse(line);
                element.transform.parent = transform;
            }
        }
    }
}