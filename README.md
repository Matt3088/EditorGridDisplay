# EditorGridDisplay
A simple class to display a grid of items using the Unity Editor.
![alt text](https://github.com/Modex2/EditorGridDisplay/blob/master/Show.png "Example usage")

##Usage
Inside the editor window class:
```c#
float scrollPosition = 0.0f;
int itemWidth = 140;
DataValue[] data = ...;
```

Inside your Editor draw function:

```c#
//Begin the grid by passing in the rectangle size, and width for each grid item
EditorGridDisplay.Begin(size, itemWidth);
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
//Then finally draw it! (and store the scroll position in a variable)
scrollPosition = EditorGridDisplay.Draw(scrollPosition, data.Length);
```
##License
MIT License

##To Do
* ~~Add a vertical scrollview into the GridDisplay~~
* Make it so you dont have to pass the grid item width to the class. Instead it should calculate it automatically.
* Just make it generally better.
* Add an option to make the window resize to the grid item dimensions.
