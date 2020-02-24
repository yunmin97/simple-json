/*
 * @Author: yunmin
 * @Email: 362279869@qq.com
 * @Date: 2020-02-23 19:51:36
 */

using System;
using System.Collections.Generic;

/// <summary>
/// extend SimpleJson libs
/// edit SimpleJson.JsonObject
/// add partial tag to the class
/// </summary>
namespace SimpleJson
{
    /// <summary>
    /// a simplejson debugger for unity
    /// </summary>
    public class Debugger
    {
        public static void Log(object message)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.Log(message);
#endif
        }
    }

    /// <summary>
    /// extend JsonArray for c#
    /// add partial to original class for extend
    /// simplejson version 1.0.0
    /// </summary>
    public partial class JsonArray : List<object>
    {
        /// <summary>
        /// create a JsonArray from json string
        /// </summary>
        /// <param name="jsonStr">json string</param>
        /// <returns>if fail then create an empty JsonArray</returns> 
        public static JsonArray Create(string jsonStr)
        {
            object obj;
            JsonArray json;
            if (SimpleJson.TryDeserializeObject(jsonStr, out obj))
            {
                json = obj as JsonArray;
            }
            else
            {
                json = new JsonArray();
            }
            return json;
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
        /// create a JsonObject from json string
        /// </summary>
        /// <param name="jsonStr">json string</param>
        /// <returns>if fail then create an empty JsonObject</returns> 
        public static JsonObject Create(string jsonStr)
        {
            object obj;
            JsonObject json;
            if (SimpleJson.TryDeserializeObject(jsonStr, out obj))
            {
                json = obj as JsonObject;
            }
            else
            {
                json = new JsonObject();
            }
            return json;
        }

        /// <summary>
        /// get json array
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonArray GetArray(string key)
        {
            if (!_members.ContainsKey(key))
            {
                Debugger.Log("key was not exist, key: " + key);
                return null;
            }
            return _members[key] as JsonArray;
        }

        /// <summary>
        /// get json object field
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonObject GetObject(string key)
        {
            if (!_members.ContainsKey(key))
            {
                Debugger.Log("key was not exist, key: " + key);
                return null;
            }
            return _members[key] as JsonObject;
        }

        /// <summary>
        /// get short field
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public short GetShort(string key, short defaultValue = 0)
        {
            if (!_members.ContainsKey(key))
            {
                Debugger.Log("key was not exist, key: " + key);
                return defaultValue;
            }
            return Convert.ToInt16(_members[key]);
        }

        /// <summary>
        /// get int field
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public int GetInt(string key, int defaultValue = 0)
        {
            if (!_members.ContainsKey(key))
            {
                Debugger.Log("key was not exist, key: " + key);
                return defaultValue;
            }
            return Convert.ToInt32(_members[key]);
        }

        /// <summary>
        /// get float field
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public float GetFloat(string key, float defaultValue = 0.0f)
        {
            if (!_members.ContainsKey(key))
            {
                Debugger.Log("key was not exist, key: " + key);
                return defaultValue;
            }
            return Convert.ToSingle(_members[key]);
        }

        /// <summary>
        /// get double field
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public double GetDouble(string key, double defaultValue = 0.0d)
        {
            if (!_members.ContainsKey(key))
            {
                Debugger.Log("key was not exist, key: " + key);
                return defaultValue;
            }
            return Convert.ToDouble(_members[key]);
        }

        /// <summary>
        /// get long field
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public long GetLong(string key, int defaultValue = 0)
        {
            if (!_members.ContainsKey(key))
            {
                Debugger.Log("key was not exist, key: " + key);
                return defaultValue;
            }
            return Convert.ToInt64(_members[key]);
        }

        /// <summary>
        /// get string field
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string GetString(string key, string defaultValue = "")
        {
            if (!_members.ContainsKey(key))
            {
                Debugger.Log("key was not exist, key: " + key);
                return defaultValue;
            }
            return Convert.ToString(_members[key]);
        }

        /// <summary>
        /// get boolean field
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public bool GetBoolean(string key, bool defaultValue = false)
        {
            if (!_members.ContainsKey(key))
            {
                Debugger.Log("key was not exist, key: " + key);
                return defaultValue;
            }
            return Convert.ToBoolean(_members[key]);
        }
                
    }

}
