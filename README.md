# EditorGridDisplay
A simple class to display a grid of items using the Unity Editor.
![alt text](https://github.com/Modex2/EditorGridDisplay/blob/master/Show.png "Example usage")

##Usage
Inside your Editor draw function:

```c#
//Begin the grid by passing in the rectangle size, and width for each grid item
EditorGridDisplay.Begin(size, 120);
//Then set the drawing function. This is what will be drawn.
EditorGridDisplay.SetDrawAction(index =>
{
    //use the current index to access data to draw the current element
    DataValue current = data[index];
    //draw Editor fields
    EditorGUILayout.TextField(current.Name);
    GUILayout.Button("Button 1", GUILayout.Width(70));
    .
    .
    .
});
//Then finally draw it!
EditorGridDisplay.Draw(data.Length);
```
##License
MIT License

##To Do
* Add a vertical scrollview into the GridDisplay
* Make it so you dont have to pass the grid item width to the class. Instead it should calculate it automatically.
* Just make it generally better.
