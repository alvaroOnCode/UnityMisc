using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

// 	XML Example
//	<?xml version="1.0" encoding="UTF-8"?>
//	<content>
//		<string id="any_id">Body</string>
//	</content>

public class XMLParser : MonoBehaviour  {

	//##################################################
	//	PUBLIC REFERENCES
	//##################################################
	[HideInInspector]
	public List<GameText> gameTexts;


	//##################################################
	//	PRIVATE REFERENCES
	//##################################################
	private XmlDocument _xmlDoc;


	//##################################################
	//	GETTERS AND SETTERS
	//##################################################
	public XmlDocument XMLDoc {
		get { return _xmlDoc; }
	}


	//##################################################
	//	STRUCTS
	//##################################################
	public struct GameText {
		public string id;
		public string text;
	};


	//##################################################
	//	ALVARO FUNCTIONS
	//##################################################
	/// <summary>
	/// Loads a new XML file located under Assets/Resources/ folder.
	/// </summary>
	/// <param name="i_xmlFilePath">XML path (even the name) to load from Resources folder.</param>
	public void LoadNewXML (string i_xmlFilePath) {
		gameTexts = new List <GameText> ();

		_xmlDoc = new XmlDocument ();
		_xmlDoc.LoadXml (((TextAsset)Resources.Load (i_xmlFilePath, typeof(TextAsset))).text);

		ReadXML ();
	}
		
	private void ReadXML () {
		foreach (XmlNode node in _xmlDoc.DocumentElement.ChildNodes) {
			GameText gameText = new GameText ();
			gameText.id = node.Attributes ["id"].Value;
			gameText.text = node.InnerXml;

			gameTexts.Add (gameText);
		}
	}

	public XmlNode GetXMLNode (string i_id) {
		return _xmlDoc.DocumentElement.SelectSingleNode ("/content/string[@id='" + i_id + "']"); // Watch the XML example at the beginning of the script to undestand the structure
	}

}