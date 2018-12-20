using AngleSharp.Parser.Html;
using System;

namespace Semestrovka.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        HtmlLoader loader;
        bool isActive;

        #region Properties

        public IParser<T> Parser
        {
            get { return parser; }
            set { parser = value; }
        }
        public bool IsActive
        {
            get { return isActive; }
        }

        public IParserSettings Settings
        {
            get { return parserSettings; }
            set
            {
                parserSettings = value;              
            }
        }
        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object> OnComplete;
        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
            loader = new HtmlLoader(parserSettings);
        }

        public void Start()
        {
            isActive = true;
            Worker();
        }

        public void Stop()
        {
            isActive = false;
        }

        private async void Worker()
        {
            if (!isActive)
            {
                OnComplete?.Invoke(this);
                return;
            }
            var source = await loader.GetSource();
            var domParser = new HtmlParser();
            var document = await domParser.ParseAsync(source);         
            var result = parser.Parse(document);
            OnNewData?.Invoke(this, result);
            OnComplete?.Invoke(this);
            isActive = false;
        }
    }
}
