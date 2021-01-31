using System.IO;
using Newtonsoft.Json;

namespace ChessOpeningRepertoire
{
    public class OpeningBook
    {
        private static readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings()
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            DateFormatHandling = DateFormatHandling.IsoDateFormat
        };

        public OpeningBook(string name)
        {
            this.Name = name;
        }

        #region Properties

        [JsonProperty(Order = 2)]
        /// <summary>
        /// Gets or sets the repertoire for Black.
        /// </summary>
        public OpeningRepertoire BlackRepertoire { get; set; } = new OpeningRepertoire(ChessboardControl.ChessColor.Black);

        [JsonIgnore]
        /// <summary>
        /// Gets or sets the full path to the file to this opening book.
        /// </summary>
        public string Filename { get; set; } = string.Empty;

        [JsonProperty(Order =0)]
        /// <summary>
        /// Gets or sets the name of this opening book.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        [JsonProperty(Order = 1)]
        /// <summary>
        /// Gets or sets the repertoire for White.
        /// </summary>
        public OpeningRepertoire WhiteRepertoire { get; set; } = new OpeningRepertoire(ChessboardControl.ChessColor.White);


        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates an instance of an OpeningBook from a file.
        /// </summary>
        /// <param name="filename">A JSON formatted file.</param>
        /// <returns></returns>
        public static OpeningBook LoadFromFile(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                var book = JsonConvert.DeserializeObject<OpeningBook>(reader.ReadToEnd(), _jsonSettings);
                book.Filename = filename;
                
                return book;
            }
        }

        /// <summary>
        /// Saves this instance to a JSON formatted file.
        /// </summary>
        public void Save()
        {
            var jsonContent = JsonConvert.SerializeObject(this, _jsonSettings);
            using (StreamWriter writer = new StreamWriter(Filename, false, System.Text.Encoding.UTF8))
            {
                writer.Write(jsonContent);
            }
        }

        public override string ToString()
        {
            return Name;
        }

        #endregion Methods
    }
}
