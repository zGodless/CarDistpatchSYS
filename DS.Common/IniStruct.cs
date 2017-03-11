using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS.Common
{
    public class IniStruct:System.Collections.IEnumerable
    {
        private System.Collections.Generic.List<string> _commentList;
        public IniStruct()
        {
            this._keyValuePairs = new System.Collections.Generic.SortedList<string, string>();
            _commentList = new System.Collections.Generic.List<string>();
        }
        public string GetComment(string key)
        {
            if (this._keyValuePairs.ContainsKey(key))
            {
                int index = this._keyValuePairs.IndexOfKey(key);
                return this._commentList[index];
            }
            return "";
        }
        public string this[int index]
        {
            get
            {
                if (this._keyValuePairs.Count > index)
                    return this._keyValuePairs.Values[index];
                else return "";
            }
            set
            {
                if (this._keyValuePairs.Count > index)
                    this._keyValuePairs.Values[index] = value;
            }
        }
        public string this[string key]
        {
            get
            {
                if (this._keyValuePairs.ContainsKey(key))
                    return this._keyValuePairs[key];
                else return "";
            }
            set
            {
                if (this._keyValuePairs.ContainsKey(key))
                    this._keyValuePairs[key] = value;
            }
        }
        public string Section { get; set; }
        private System.Collections.Generic.SortedList<string, string> _keyValuePairs;
        public void Add(string key, string value, string commont)
        {
            this._keyValuePairs.Add(key, value);
            this._commentList.Add(commont);
        }
        public override string ToString()
        {
            return string.Format("{0}", this.Section);
        }

        public bool ContainKey(string key)
        {
            return this._keyValuePairs.ContainsKey(key);
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return this._keyValuePairs.GetEnumerator();
        }
    }
}
