/*
 * @Author: yunmin
 * @Email: 362279869@qq.com
 * @Date: 2020-02-23 19:51:36
 */

using System.IO;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// extend SimpleJson libs
/// edit SimpleJson.JsonObject
/// add partial tag to the class
/// </summary>
namespace SimpleJson
{
    /// <summary>
    /// extend JsonArray for c#
    /// add partial to original class for extend
    /// simplejson version 1.0.0
    /// </summary>
    public partial class JsonArray : List<object>
    {
        /// <summary>
        /// sync read file from Resources fold of unity project
        /// </summary>
        /// <param name="relativepath">relative to Resources folder of unity without file format name</param>
        /// <param name="json">json array</param>
        /// <returns>success o fail</returns>
        public static bool Read(string relativepath, out JsonArray json)
        {
            bool success = false;
            var file = Resources.Load(relativepath) as TextAsset;
            if (file != null)
            {
                object obj;
                if (SimpleJson.TryDeserializeObject(file.text, out obj))
                {
                    json = obj as JsonArray;
                    success = true;
                }
                else
                {
                    json = null;
                    Debugger.Log("deserialize fail: " + relativepath);
                }
            }
            else
            {
                json = null;
                Debugger.Log("load file fail: " + relativepath);
            }

            return success;
        }
    }

    /// <summary>
    /// extend JsonObject for c#
    /// add partial to original class for extend
    /// simplejson version 1.0.0
    /// </summary>
    public partial class JsonObject : IDictionary<string, object>
    {
        /// <summary>
        /// sync read file from Resources fold of unity project
        /// </summary>
        /// <param name="relativepath">relative to Resources folder of unity without file format name</param>
        /// <param name="json">json object</param>
        /// <returns>success o fail</returns>
        public static bool Read(string relativepath, out JsonObject json)
        {
            bool success = false;
            var file = Resources.Load(relativepath) as TextAsset;
            if (file != null)
            {
                object obj;
                if (SimpleJson.TryDeserializeObject(file.text, out obj))
                {
                    json = obj as JsonObject;
                    success = true;
                }
                else
                {
                    json = null;
                    Debugger.Log("deserialize fail: " + file.text);
                }
            }
            else
            {
                json = null;
                Debugger.Log("load file fail: " + relativepath);
            }

            return success;
        }
        
        /// <summary>
        /// write json file to disk for unity project
        /// </summary>
        /// <param name="json">json string</param>
        /// <param name="filename">json file name without file format name</param>
        public static void Write(string json, string filename, string extend = ".json")
        {
            if (!string.IsNullOrEmpty(filename))
            {
                // fix file path
                string fullpath = Application.dataPath;
                if (-1 == filename.IndexOf("/", 0, 1))
                {
                    fullpath += "/";
                }
                fullpath += filename;
                fullpath += extend;
                FileInfo file = new FileInfo(fullpath);
                StreamWriter sw = file.CreateText();
                sw.WriteLine(json);
                sw.Close();
                sw.Dispose();
            }
            else
            {
                Debugger.Log("file name is empty or null");
            }
        }

        public static JsonObject FromVector2(Vector2 v)
        {
            var vdata = new JsonObject();
            if (v.x != 0) vdata.Add("x", v.x);
            if (v.y != 0) vdata.Add("y", v.y);
            return vdata;
        }
        public static Vector2 ToVector2(JsonObject obj)
        {
            float x = obj.GetFloat("x");
            float y = obj.GetFloat("y");
            return new Vector2(x, y);
        }
        
        public static JsonObject FromVector3(Vector3 v)
        {
            var vdata = new JsonObject();
            if (v.x != 0) vdata.Add("x", v.x);
            if (v.y != 0) vdata.Add("y", v.y);
            if (v.z != 0) vdata.Add("z", v.z);
            return vdata;
        }
        public static Vector3 ToVector3(JsonObject obj)
        {
            float x = obj.GetFloat("x");
            float y = obj.GetFloat("y");
            float z = obj.GetFloat("z");
            return new Vector3(x, y, z);
        }
        
        public static JsonObject FromVector4(Vector4 v)
        {
            var vdata = new JsonObject();
            if (v.x != 0) vdata.Add("x", v.x);
            if (v.y != 0) vdata.Add("y", v.y);
            if (v.z != 0) vdata.Add("z", v.z);
            if (v.w != 0) vdata.Add("w", v.w);
            return vdata;
        }
        public static Vector4 ToVector4(JsonObject obj)
        {
            float x = obj.GetFloat("x");
            float y = obj.GetFloat("y");
            float z = obj.GetFloat("z");
            float w = obj.GetFloat("w");
            return new Vector4(x, y, z, w);
        }

        public static JsonObject FromQuaternion(Quaternion q)
        {
            var qdata = new JsonObject();
            if (q.w != 0) qdata.Add("w", q.w);
            if (q.x != 0) qdata.Add("x", q.x);
            if (q.y != 0) qdata.Add("y", q.y);
            if (q.z != 0) qdata.Add("z", q.z);
            return qdata;
        }
        public static Quaternion ToQuaternion(JsonObject obj)
        {
            float x = obj.GetFloat("x");
            float y = obj.GetFloat("y");
            float z = obj.GetFloat("z");
            float w = obj.GetFloat("w");
            return new Quaternion(x, y, z, w);
        }

        public static JsonObject FromColor(Color c)
        {
            var cdata = new JsonObject();
            if (c.r != 0) cdata.Add("r", c.r);
            if (c.g != 0) cdata.Add("g", c.g);
            if (c.b != 0) cdata.Add("b", c.b);
            if (c.a != 0) cdata.Add("a", c.a);
            return cdata;
        }
        public static Color ToColor(JsonObject obj)
        {
            Color c = new Color();
            c.r = obj.GetFloat("r");
            c.g = obj.GetFloat("g");
            c.b = obj.GetFloat("b");
            c.a = obj.GetFloat("a");
            return c;
        }

        public static JsonObject FromRect(Rect r)
        {
            var result = new JsonObject();
            if (r.x != 0) result.Add("x", r.x);
            if (r.y != 0) result.Add("y", r.y);
            if (r.height != 0) result.Add("height", r.height);
            if (r.width != 0) result.Add("width", r.width);
            return result;
        }
        public static Rect ToRect(JsonObject obj)
        {
            Rect r = new Rect();
            r.x = obj.GetFloat("x");
            r.y = obj.GetFloat("y");
            r.height = obj.GetFloat("height");
            r.width = obj.GetFloat("width");
            return r;
        }

        public static JsonObject FromRectOffset(RectOffset r)
        {
            var result = new JsonObject();
            if (r.bottom != 0) result.Add("bottom", r.bottom);
            if (r.left != 0) result.Add("left", r.left);
            if (r.right != 0) result.Add("right", r.right);
            if (r.top != 0) result.Add("top", r.top);
            return result;
        }
        public static RectOffset ToRectOffset(JsonObject obj)
        {
            RectOffset r = new RectOffset();
            r.bottom = obj.GetInt("bottom");
            r.left = obj.GetInt("left");
            r.right = obj.GetInt("right");
            r.top = obj.GetInt("top");
            return r;
        }

    }

}
