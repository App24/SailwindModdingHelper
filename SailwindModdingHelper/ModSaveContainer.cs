using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;
using UnityModManagerNet;

namespace SailwindModdingHelper
{
    public abstract class ModSaveContainer
    {
        public static T Load<T>(UnityModManager.ModEntry modEntry) where T : ModSaveContainer
        {
			string s;
			if (GameState.modData != null && GameState.modData.TryGetValue(modEntry.Info.Id, out s))
			{
				Debug.Log("Proceeding to parse save data for " + modEntry.Info.Id);
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
				using (StringReader stringReader = new StringReader(s))
				{
					return (T)((object)xmlSerializer.Deserialize(stringReader));
				}
			}
			Debug.Log("Cannot load data from save file. Using defaults for " + modEntry.Info.Id);
			return Activator.CreateInstance<T>();
		}

		public static void Save<T>(T saveContainer, UnityModManager.ModEntry modEntry) where T : ModSaveContainer
        {
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			using (StringWriter stringWriter = new StringWriter())
			{
				xmlSerializer.Serialize(stringWriter, saveContainer);
				GameState.modData[modEntry.Info.Id] = stringWriter.ToString();
				Debug.Log("Packed save data for " + modEntry.Info.Id);
			}
		}

		public abstract void Save();
    }
}
