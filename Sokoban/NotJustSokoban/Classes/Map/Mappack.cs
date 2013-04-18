using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public class Mappack
    {
        // Class variables

        // Properties
        public int CurrentMapIndex { get; private set; }
        public Map CurrentMap { get; private set; }
        public string[] MapList { get; private set; }
        public string FileExtension { get; set; }
        public string MapsSourceType { get; set; }
        public string Directory { get; set; }

        public Mappack(string mappackName)
        {
            this.CurrentMapIndex = 0;
            Dictionary<string, object> mappackData = MappackLoader.Load(mappackName);

            AssignProperties(mappackData);

            LoadMap();
        }

        // Assign Properties
        private void AssignProperties(Dictionary<string, object> mappackData)
        {
            this.MapList = (string[])mappackData["mapList"];
            this.FileExtension = (string)mappackData["fileExtension"];
            this.MapsSourceType = (string)mappackData["mapsSourceType"];
            this.Directory = (string)mappackData["directory"];
        }


        //// MapList iteration
        //private void PreviousMapIndex()
        //{
        //    this.CurrentMapIndex--;

        //    if (this.CurrentMapIndex < 0)
        //    {
        //        this.CurrentMapIndex++;
        //        throw new IndexOutOfRangeException("The CurrentMapIndex cannot be less than 0. CurrentMapIndex returned to first map");
        //    }
        //}

        //private void NextMapIndex()
        //{
        //    this.CurrentMapIndex++;

            
        //}

        ///*
        //public Map GetPreviousMap()
        //{
        //    PreviousMap();

        //    return this.CurrentMap;
        //}

        //public Map GetNextMap()
        //{
        //    NextMap();

        //    return this.CurrentMap;
        //}
        //*/

        //public void PreviousMap()
        //{
        //    PreviousMapIndex();

        //    LoadMap(); 
        //}

        //Returns the next available map or null if there isn't any
        public Map NextMap()
        {
            if (this.CurrentMapIndex >= MapList.Length)
            {
                return null;
            }
            LoadMap();
            this.CurrentMapIndex++;
            return this.CurrentMap;
        }


        // Load Map
        private void LoadMap()
        {
            Map.Instance.Load(this.MapList[this.CurrentMapIndex], this.MapsSourceType);
            this.CurrentMap = Map.Instance;
        }
    }
}
