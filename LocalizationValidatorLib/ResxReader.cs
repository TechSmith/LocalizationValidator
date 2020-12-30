using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Xml;
using SystemInterface.IO;

namespace LocalizationValidatorLib
{
   public class ResxReader : IResourceReader
   {
      private readonly string _resxFilePath;
      private readonly IFile _file;
      private XmlTextReader _xmlReader;
      private readonly List<ResourceString> _resourceStrings;
      public ResxReader( string resxFilePath, IFile file )
      {
         _resxFilePath = resxFilePath;
         _file = file;

         if ( !_file.Exists( _resxFilePath ) )
         {
            throw new InvalidOperationException( $"File {_resxFilePath} does not exist" );
         }

         _resourceStrings = new List<ResourceString>();
         
         var resxFileText = file.ReadAllText( _resxFilePath );

         _xmlReader = new XmlTextReader( GenerateStreamFromString( resxFileText ) );
         while ( _xmlReader.Read () )
         {
            if ( _xmlReader.NodeType != XmlNodeType.Element )
               continue;

            switch ( _xmlReader.LocalName )
            {
               case "resheader":
                  //ParseHeaderNode ( header );
                  break;
               case "data":
                  ParseDataNode ( false );
                  break;
               case "metadata":
                  //ParseDataNode ( true );
                  break;
            }
         }
      }
      
      private static Stream GenerateStreamFromString(string s)
      {
         var stream = new MemoryStream();
         var writer = new StreamWriter(stream);
         writer.Write(s);
         writer.Flush();
         stream.Position = 0;
         return stream;
      }

      public IEnumerable<ResourceString> GetAllResourceStrings()
      {
         foreach ( var s in _resourceStrings )
         {
            yield return s;
         }
      }
      
      private string? GetAttribute (string name)
      {
         if (!_xmlReader.HasAttributes)
            return null;
         for (int i = 0; i < _xmlReader.AttributeCount; i++) {
            _xmlReader.MoveToAttribute (i);
            if (String.Compare (_xmlReader.Name, name, true) == 0) {
               string v = _xmlReader.Value;
               _xmlReader.MoveToElement ();
               return v;
            }
         }
         _xmlReader.MoveToElement ();
         return null;
      }
      
      private string GetDataValue (bool meta, out string comment)
      {
         string value = null;
         comment = null;
         while (_xmlReader.Read ()) {
            if (_xmlReader.NodeType == XmlNodeType.EndElement && _xmlReader.LocalName == (meta ? "metadata" : "data"))
               break;

            if (_xmlReader.NodeType == XmlNodeType.Element) {
               if (_xmlReader.Name.Equals ("value")) {
                  _xmlReader.WhitespaceHandling = WhitespaceHandling.Significant;
                  value = _xmlReader.ReadString ();
                  _xmlReader.WhitespaceHandling = WhitespaceHandling.None;
               } else if (_xmlReader.Name.Equals ("comment")) {
                  _xmlReader.WhitespaceHandling = WhitespaceHandling.Significant;
                  comment = _xmlReader.ReadString ();
                  _xmlReader.WhitespaceHandling = WhitespaceHandling.None;
                  if (_xmlReader.NodeType == XmlNodeType.EndElement && _xmlReader.LocalName == (meta ? "metadata" : "data"))
                     break;
               }
            }
            else
               value = _xmlReader.Value.Trim ();
         }
         return value;
      }
      
      private void ParseDataNode (bool meta)
      {
         Point pos = new Point (_xmlReader.LineNumber, _xmlReader.LinePosition);
         string name = GetAttribute ("name");
         string type_name = GetAttribute ("type");
         string mime_type = GetAttribute ("mimetype");


         string comment = null;
         string value = GetDataValue (meta, out comment);

         ResourceString s = new ResourceString()
         {
            Id = name,
            Text = value,
            Comment = ""
         };
         
         _resourceStrings.Add( s );
      }
   }
}