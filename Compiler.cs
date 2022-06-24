using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace C_sharp_text_parsing
{
    class Compiler
    {
        public void SetData(byte[] data_)
        {
            data = new List<byte>(data_);

            Position = 0;
        }

        List<byte> data;

        byte[] buffer
        {
            get => data.ToArray();
        }

        void Write(int input)
        {
            data.AddRange(BitConverter.GetBytes(input));
        }

        void Write(string input)
        {

            Write(input.Length);
            data.AddRange(Encoding.ASCII.GetBytes(input));
        }

        void Write(string[] input)
        {
            Write(input.Length);

            foreach (string st in input)
            {
                Write(st);
                Console.WriteLine(st);
            }
        }


        void Write(Area area) 
        {
            Write(area.name);
            Write(area.description);
            Write(area.areasToGo);
        }

        int Position=0;

        public int ReadInt()
        {
            int toReturn = BitConverter.ToInt32(buffer,Position);
            Position += 4;
            Console.WriteLine($"Among us {toReturn}");
            return toReturn;
        }

        public string ReadString()
        {
            int Length = ReadInt();
            Console.WriteLine(Length);
            string toReturn = Encoding.ASCII.GetString(buffer, Position, Length);
            Position += Length;
            return toReturn;
        }

        public string[] ReadStrings()
        {
            int Length = ReadInt();
            string[] toReturn = new string[Length];
            for (int i = 0; i < Length; i++)
            {
                toReturn[i] = ReadString();
            }
            return toReturn;
        }

        public Area ReadArea()
        {
            Area area = new Area(ReadString());
            area.description = ReadString();
            area.areasToGo = ReadStrings();

            return area;
        }

        public void Compile(Area[] areas)
        {
            data = new List<byte>();

            Write(constants.Settings.ToStrings());

            Write(areas.Length);
            foreach (Area area in areas)
            {
                Write(area);
            }
            Save();
        }

        public void Save()
        {
            using (FileStream stream = File.Create(Path.Join(Directory.GetCurrentDirectory(), "compiled.dat")))
            {
                stream.Write(buffer, 0, buffer.Length);
            }

            Console.WriteLine("Saved");
        }

        public Area[] Decompile()
        {
            if (data == null)
                data = new List<byte>();

            ReadInt();
            string[] bruh = new string[] { ReadString(), ReadString(), ReadString(), ReadString(), ReadString() };

            constants.Settings.SetValues(bruh);
            int Length = ReadInt();
            List<Area> areas = new List<Area>();
            for (int i = 0; i < Length; i++)
            {
                areas.Add(ReadArea());
            }

            return areas.ToArray();
        }
    }
}
