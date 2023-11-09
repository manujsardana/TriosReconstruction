using System;
using TriosReconstruction.Interfaces;

namespace TriosReconstruction.Service
{
    public class ReconstructionEngine : IReconstructionEngine
    {
        private readonly string BaseModel = "1oene2enoe3neoo4aei5iia";
        private Dictionary<int, string> dict = new();
        public void ProcessImage(string imageText)
        {
            var key = imageText.GetHashCode();

            if(dict.ContainsKey(key))
            {
                dict[key] = imageText.ToString();
            }
            else
            {
                dict.Add(key, imageText);
            }
        }

        public string GetReconstructionModel()
        {

            var values = dict.Values.ToList();
            string model = values[0];
            for (int i = 1; i < values.Count; i++)
            {
                model = Concat(model, values[i]);
            }

            return model;
        }

        private static string Concat(string s1, string s2)
        {
            String s = s1;
            int L = s2.Length;
            while (L > 0)
            {
                String common = s2[..L];
                if (s1.EndsWith(common))
                {
                    s = string.Concat(s1, s2.AsSpan(L));
                    break;
                }
                L--;
            }

            return s;
        }

        public string GetReconstructionModelBackup()
        {
            List<char> list = new();
            foreach(var value in dict.Values)
            {
                if(!list.Any())
                {
                    foreach(char ch in value)
                    {
                        list.Add(ch);
                    }
                }
                else
                {
                    int index = list.Count-1;
                    foreach (char ch in value)
                    {
                        if (index != -1)
                        {
                            if (ch == list[index])
                            {
                                index--;
                                continue;
                            }
                            else
                            {
                                list.Add(ch);
                                index = -1;
                            }
                        }
                        else
                            list.Add(ch);
                    }
                }
            }

            return new string(list.ToArray());
      
        }

        public string GetBaseModel()
        {
            return BaseModel;
        }
    }
}
