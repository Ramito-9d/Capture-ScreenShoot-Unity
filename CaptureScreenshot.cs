using UnityEngine;
using System.Collections;
using System.IO;

public class CaptureScreenshot : MonoBehaviour
{
	public enum SCQuality {
		LOW = 1,
		MEDIUM = 2,
		GOOD = 3,
		HIGH = 4,
		FANTASTIC = 5
	};

	public SCQuality quality = SCQuality.LOW;

	public string path = "";
	public string fileName = "Screenshot";

	private int fileNo = 0;

	void Start()
	{
		if(path.Length <= 0)
			path = "Assets/Screenshots";

		if(!Directory.Exists(path))
			Directory.CreateDirectory(path);

		if(!Directory.Exists(path))
			Directory.CreateDirectory(path);

		if(fileName.Contains("."))
			fileName = fileName.Substring(0,fileName.LastIndexOf("."));
	}

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.K))
		{
			string thisFileName = fileName+"-"+fileNo+".png";
			string thisFilePath = path+"/"+thisFileName;

			bool fileWritten = false;

			while(fileWritten == false)
			{
				if(!System.IO.File.Exists(thisFilePath))
				{
					Application.CaptureScreenshot(thisFilePath,(int)quality);
					fileWritten = true;
				}
				fileNo += 1;

				thisFileName = fileName+"-"+fileNo+".png";
				thisFilePath = path+"/"+thisFileName;
			}
		}
	}
}
