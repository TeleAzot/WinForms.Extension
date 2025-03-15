# WinForms.Extension
Get the nuget package: ``` dotnet add package StoxCoding.WinForms.Extension ```
## DarkenForm
The DarkenForm extension offers a method to darken a System.Windows.Forms.Form when showing another one on top of it.
![image](https://github.com/user-attachments/assets/1fee7fd0-11df-4039-97fb-78d0a0408ebd)

There are two ways to call the DarkenForm extension. The method DarkenForm has an overload where you can customize the opacity and the color for the form that will be darkened.  
Here is an example of a call to DarkenForm:  
![image](https://github.com/user-attachments/assets/debc3bfe-8fec-45df-a3eb-c26f9e4dcd15)  
(Method with standard opacity and color)
  
![image](https://github.com/user-attachments/assets/6552a6ad-c78c-4291-a12d-c35c42847a93)  
(Method with custom opacity and color)

-----

## TextBoxHighlighter
The TextBoxHighlighter class offers a method to activate customizable highlighting on a collection System.Windows.Forms.TextBox on their Enter event.  
![image](https://github.com/user-attachments/assets/fa039feb-57da-4a7f-bd17-cf0b5fcfa63b)

You can either activate TextBox highlighting for all TextBoxes in a Form or just a collection of them.  
Here is an example of a call to DarkenForm:  
![image](https://github.com/user-attachments/assets/e7ed2271-b89b-47b6-9150-72085381cebb)  
(Apply highlighting for all TextBoxes in a form)

![image](https://github.com/user-attachments/assets/cd5efaf5-c03a-44c8-8efd-d0c4b3d9d5d1)  
(Apply highlighting for all TextBoxes in a custom collection.

> [!TIP]
You can also modify the HighLightColor property to set your custom hightlighting color. The default Color is yellow.
