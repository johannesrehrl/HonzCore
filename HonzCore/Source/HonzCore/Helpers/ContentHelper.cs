using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace HonzCore.Helpers
{
    class ContentHelper : IHelper
    {
        private static ContentHelper _instance;

        private static Dictionary<String, Texture2D> texture;
        
        public static ContentHelper instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ContentHelper();
                }
                return _instance;
            }
        }

        public void Draw(GameTime time)
        {
            
        }

        public void Initialize()
        {
            texture = new Dictionary<String, Texture2D>();
        }
      
        public static void LoadTextures(ContentManager contentManager, string contentFolder)
        {                                                                                       //i woas oba i hob keine ahnung wie i des sunst doa soi
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory() + "/" + contentManager.RootDirectory + "/" + contentFolder);
            if (!dir.Exists)
                throw new DirectoryNotFoundException();

            FileInfo[] files = dir.GetFiles("*.png");
            foreach(FileInfo file in files)
            {
                string key = Path.GetFileNameWithoutExtension(file.Name);

                texture[key] = contentManager.Load<Texture2D>(contentFolder + "/" + key);
            }
        }

        public static Texture2D GetTexture(string textureFile)
        {
            try
            {
                return texture[textureFile];
            }
            catch
            {
                throw new InvalidOperationException("File: " + textureFile + " does not exist");
            }
        }

        public void Update(GameTime time)
        {
            
        }
    }
}
