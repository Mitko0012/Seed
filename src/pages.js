const pages = [`<h1>Introduction</h1>
<hr>
<p>This is the documentation of Seed, a 2D game engine for creating Windows and Linux games built in C#.</p>
<h3>Installation</h3>
<p>Seed can be installed these ways:</p>
<ul>
    <li>Windows:</li>
    <ul>
        <li>Clone the source code from <a class="textAnchor" href="https://github.com/Mitko0012/Seed" target="_blank">GitHub</a>.</li>
        <li>Download the release from <a class="textAnchor" href="https://github.com/Mitko0012/Seed/releases/" target="_blank">GitHub</a>.</li>
        <li>Get the SeedLib package from <a class="textAnchor" href="https://www.nuget.org/packages/SeedLib/" target="_blank">NuGet</a>.</li>
    </ul>
</ul>
<h3>Dependencies</h3>
<ul>
    <li>Windows</li>
    <ul>
        <li>Target framework: net8.0-windows</li>
        <li>NAudio 2.2.1</li>
    </ul>
</ul>
<br>
<p>After installing, create a new C# project targeting the target framework for the platform you're using and add a reference to Seed.</p>
<p>If you cloned the source code or downloaded the release from GitHub, then NAudio is already installed. If you got the SeedLib NuGet package, then go ahead and get the NAudio package from <a class="textAnchor" href="https://www.nuget.org/packages/NAudio" target="_blank">NuGet</a> and add it to your project.</p>`,
`<h1><code>public abstract class GameLogic</code></h1>
<hr> 
<p>The main class of Seed. All Seed scripts derive from it.</p>
<h3>Constructors</h3>
<hr>
<code>public GameLogic()</code>
<p>Creates a new instance of the GameLogic class. Since the class is abstract, a new instance cannot be created directly.</p>
<p>Exceptions:</p>
<ul>
    <li><code>Exception</code>: Thrown if a GameLogic object gets created after the game loop is started.</li>
</ul>
<br>
<h3>Fields</h3>
<hr>
<code>public static Graphics G</code>
<p>The object used to draw elements on the game window. The user doesn't need to interact with it directly.</p>
<br>
<code>public static double UnitsOnCanvas</code>
<p>The number of game units currently present on the game window. 10 by default.</p>
<br>
<code>public static List&lt;STexture&gt; TileTextures</code>
<p>A list of STextures that represents the tile map textures. The item with index 0 is an empty STexture.</p>
<br>
<h3>Properties</h3>
<hr>
<code>public static int FrameNumber {get;}</code>
<p>Gets the count of the frames that have been sucessfully rendered. The value of it is 0 at the start. It increases by 1 with each sucessfully rendered frame.</p>
<br>
<code>public static int Width {get;}</code>
<p>Gets the width of the game window. 800 by default.</p>
<br>
<code>public static int Height {get;}</code>
<p>Gets the height of the game window. 600 by default.</p>
<br>
<code>public static int Height {get;}</code>
<p>Gets the height of the game window. 600 by default.</p>
<br>
<code>public static int DesiredFps {get; set;}</code>
<p>Gets or sets the desired FPS of the game. 60 by default.</p>
<p>Exceptions:</p>
<ul>
    <li><code>Exception</code>: Thrown when the value is attempted to be set to 0 or less.</li>
</ul>
<br>
<code>public static int Fps {get;}</code>
<p>Gets the actual FPS of the game.</p>
<br>
<code>public static double DeltaTime {get;}</code>
<p>Gets the time between the current and last frame.</p>
<br>
<h3>Methods</h3>
<hr>
<code>public abstract void OnStart()</code>
<p>Called when the game loop starts. It has to be overriden. It can be used to provide code to be executed when the game loop is started.</p>
<br>
<code>public abstract void OnFrame()</code>
<p>Called each frame. It has to be overriden. It can be used to provide code to be executed each frame.</p>
<br>
<code>public static void StartGameLoop()</code>
<p>Starts the game loop and opens the game window. If you have classes inheriting from <code>GameLogic</code>, their <code>OnStart</code> and <code>OnUpdate</code> methods won't get called unless the inheriting class got instantiated as an object before starting the game loop.</p>
<p>Exceptions:</p>
<ul>
    <li><code>Exception</code>: Thrown if the method is called more than once.</li>
</ul>
<br>
<code>public static void SetTitle(string title)</code>
<p>Sets the title of the game window.</p>
<p>Parameters:</p>
<ul>
    <li><code>title</code>: The text that gets set as the title of the game window.</li>
</ul>
<br>
<code>public static void SetSize(int width, int height)</code>
<p>Sets the size of the game window.</p>
<p>Parameters:</p>
<ul>
    <li><code>width</code>: A value in pixels that gets set as the width of the game window.</li>
    <li><code>height</code>: A value in pixels that gets set as the height of the game window.</li>22
</ul>
<br>
<code>public static void SetIcon(Icon icon)</code>
<p>Sets the icon of the game winodw.</p>
<p>Parameters:</p>
<ul>
    <li><code>icon</code>: The icon that gets set as the game window's icon.</li>
</ul>
<br>
<code>public static void AllowResizing(bool value)</code>
<p>Enables or disables resizing the game window.</p>
<p>Parameters:</p>
<ul>
    <li><code>value</code>: Defines whether the game window should be allowed to be resized or not.</li>
</ul>
<br>
<code>public static void SetFullScreen(bool value)</code>
<p>Sets the game window's size mode to windowed or full screen.</p>
<p>Parameters:</p>
<ul>
    <li><code>value</code>: Describes the size mode the game window is to be set. True if full screen, false if windowed.</li>
</ul>
<br>
<code>public static void SetColor(Color color)</code>
<p>Sets the background color of the game window.</p>
<p>Parameters:</p>
<ul>
    <li><code>color</code>: The color which the window's background color is to be set to.</li>
</ul>
<br>
<code>public static void Exit()</code>
<p>Exits the game.</p>
<br> `,
`<h1><code>public abstract class Element</code></h1>
<hr>
<p>The class from which each game element class derives. A game element is an object that gets displayed on the screen. It has features such as collision checking.</p>
<h3>Fields</h3>
<hr>
<code>public double PosX</code>
<p>The X position of the element in game units.</p>
<br>
<code>public double PosY</code>
<p>The Y position of the element in game units.</p>
<br>
<code>public bool IsSticky</code>
<p>True if the element should be sticky(independent from the camera positionm), false if not.</p>
<br>
<h3>Methods</h3>
<hr>
<code>public virtual void Draw()</code>
<p>Draws the element on the game window.</p>
<br>`,
`<h1><code>public class CollidableElement : Element</code></h1>
<hr>
<p>This class represents elements which can be directly checked for collision without creating colliders.</p>
<h3>Fields</h3>
<hr>
<code>public double Width</code>
<p>The width of the element in game units.</p>             
<br>
<code>public double Height</code>
<p>The height of the element in game units.</p>             
<br>
<code>public double RotationCenterX</code>
<p>The X position of the center of rotation of the element in game units. Relative to the PosX of the element. 0 by default.</p>             
<br>
<code>public double RotationCenterY</code>
<p>The Y position of the center of rotation of the element in pixels. Relative to the PosY of the element. 0 by default.</p>             
<br>
<code>public double Angle</code>
<p>The angle of rotation of the element. 0 by default.</p>             
<br>`,
`<h1><code>public class Ellipse : CollidableElement</code></h1>
<hr>
<p>A full ellipse element.</p>
<h3>Constructors</h3>
<hr>
<code>public Ellipse(double posX, double posY, double width, double height, Color color)</code>
<p>Creates a new instance of the Ellipse class.</p>
<p>Parameters:</p>
<ul>
    <li><code>posX</code>: Value to be set as the X position.</li>
    <li><code>posY</code>: Value to be set as the Y position.</li>
    <li><code>width</code>: Value to be set as the width.</li>
    <li><code>height</code>: Value to be set as the height.</li>
    <li><code>color</code>: Value to be set as the background color.</li>
</ul>
<br>
<h3>Fields</h3>
<hr>
<code>public Color BackgroundColor</code>
<p>The color of the ellipse.</p>
<br>
<h3>Methods</h3>
<hr>
<code>public override void Draw()</code>
<p>Draws the ellipse on the game window.</p>
<br>`,
`<h1><code>public class EmptyEllipse : CollidableElement</code></h1>
<hr>
<p>An empty ellipse element.</p>
<h3>Constructors</h3>
<hr>
<code>public EmptyEllipse(double posX, double posY, double height, double width, double ellipseWidth, Color color)</code>
<p>Creates a new instance of the EmptyEllipse class.</p>
<p>Parameters:</p>
<ul>
    <li><code>posX</code>: Value to be set as the X position.</li>
    <li><code>posY</code>: Value to be set as the Y position.</li>
    <li><code>width</code>: Value to be set as the width.</li>
    <li><code>height</code>: Value to be set as the height.</li>
    <li><code>ellipseWidth</code>: Value to be set as the outline width</li>
    <li><code>color</code>: Value to be set as the color.</li>
</ul>
<br>
<h3>Fields</h3>
<hr>
<code>public double OvalWidth</code>
<p>The width of the outline of the ellipse in game units.</p>
<br>
<code>public Color Color</code>
<p>The color of the outline of the ellipse.</p>
<br>
<h3>Methods</h3>
<hr>
<code>public override void Draw()</code>
<p>Draws the empty ellipse on the game window.</p>
<br>`,
`<h1><code>public class FullRectangle : CollidableElement</code></h1>
<hr>
<p>A full rectangle element.</p>
<h3>Constructors</h3>
<hr>
<code>public FullRectangle(double posX, double posY, double width, double height, Color color)</code>
<p>Creates a new instance of the FullRectange class.</p>
<p>Parameters:</p>
<ul>
    <li><code>posX</code>: Value to be set as the X position.</li>
    <li><code>posY</code>: Value to be set as the Y position.</li>
    <li><code>width</code>: Value to be set as the width.</li>
    <li><code>height</code>: Value to be set as the height.</li>
    <li><code>color</code>: Value to be set as the background color.</li>
</ul>
<br>
<h3>Fields</h3>
<hr>
<code>public Color BackgroundColor</code>
<p>The color of the rectangle.</p>
<br>
<h3>Methods</h3>
<hr>
<code>public override void Draw()</code>
<p>Draws the full rectangle on the game window.</p>
<br>`,
`<h1><code>public class EmptyRectangle : CollidableElement</code></h1>
<hr>
<p>An empty rectange element.</p>
<h3>Constructors</h3>
<hr>
<code>public EmptyRectangle(double posX, double posY, double width, double height, double rectangleWidth, Color color)</code>
<p>Creates a new instance of the EmptyRectange class.</p>
<p>Parameters:</p>
<ul>
    <li><code>posX</code>: Value to be set as the X position.</li>
    <li><code>posY</code>: Value to be set as the Y position.</li>
    <li><code>width</code>: Value to be set as the width.</li>
    <li><code>height</code>: Value to be set as the height.</li>
    <li><code>ellipseWidth</code>: Value to be set as the outline width</li>
    <li><code>color</code>: Value to be set as the color.</li>
</ul>
<br>
<h3>Fields</h3>
<hr>
<code>public double RectangleWidth</code>
<p>The width of the outline of the rectangle in game units.</p>
<br>
<code>public Color Color</code>
<p>The color of the outline of the rectangle.</p>
<br>
<h3>Methods</h3>
<hr>
<code>public override void Draw()</code>
<p>Draws the empty rectangle on the window.</p>
<br>`,
`<h1><code>public class Sprite : CollidableElement</code></h1>
<hr>
<p>A sprite element.</p>
<h3>Constructors</h3>
<hr>
<code>public Sprite(double posX, double posY, double sizeX, double sizeY, STexture texture)</code>
<p>Creates a new instance of the Ellipse class.</p>
<p>Parameters:</p>
<ul>
    <li><code>posX</code>: Value to be set as the X position.</li>
    <li><code>posY</code>: Value to be set as the Y position.</li>
    <li><code>sizeX</code>: Value to be set as the width.</li>
    <li><code>sizeY</code>: Value to be set as the height.</li>
    <li><code>texture</code>: Value to be set as the image texture.</li>
</ul>
<br>
<h3>Properties</h3>
<hr>
<code>public STexture Texture {get; set;}</code>
<p>Gets or sets the image texture of the sprite.</p>
<br>
<h3>Methods</h3>
<hr>
<code>public override void Draw()</code>
<p>Draws the sprite onto the screen.</p>
<br>`,
`<h1><code>public class Line : Element</code></h1>
<hr>
<p>A line element.</p>
<h3>Constructors</h3>
<hr>
<code>public Line(double posX, double posY, double endPosX, double endPosY, double width, Color color)</code>
<p>Creates a new instance of the Line class.</p>
<p>Parameters:</p>
<ul>
    <li><code>posX</code>: Value to be set as the X position.</li>
    <li><code>posY</code>: Value to be set as the Y position.</li>
    <li><code>endPosX</code>: Value to be set as the end X position.</li>
    <li><code>endPosY</code>: Value to be set as the end Y position.</li>
    <li><code>width</code>: Value to be set as the width of the line.</li>
    <li><code>color</code>: Value to be set as the color.</li>
</ul>
<br>
<h3>Fields</h3>
<hr>
<code>public double EndPosX</code>
<p>The X position of the end point of the line in game units.</p>
<br>
<code>public double EndPosY</code>
<p>The Y position of the end point of the line in game units.</p>
<br>
<code>public double Width</code>
<p>The width of the line in game units.</p>
<br>
<code>public Color Color</code>
<p>The color of the line.</p>
<br>
<h3>Methods</h3>
<hr>
<code>public override void Draw()</code>
<p>Draws the line on the game window.</p>
<br>`,
`<h1><code>public class Text : Element</code></h1>
<hr>
<p>A text element.</p>
<h3>Constructors</h3>
<hr>
<code>public Text(double posX, double posY, double size, string font, string text)</code>
<p>Creates a new instance of the Text class.</p>
<p>Parameters:</p>
<ul>
    <li><code>posX</code>: Value to be set as the X position.</li>
    <li><code>posY</code>: Value to be set as the Y position.</li>
    <li><code>size</code>: Value to be set as the size.</li>
    <li><code>font</code>: Value to be set as the font.</li>
    <li><code>text</code>: Value to be set as the display text.</li>
</ul>
<br>
<h3>Fields</h3>
<hr>
<code>public Color Color</code>
<p>The color of the text. Black by default.</p>
<br>
<code>public string DisplayText</code>
<p>The content of the text.</p>
<br>
<code>public string Font</code>
<p>The font of the text. Arial by default.</p>
<br>
<code>public double Size</code>
<p>The size of the text in game units.</p>
<br>
<code>public HTextAlignment HorisontalAlignment</code>
<p>The horizontal alignment of the text. Left by default.</p>
<br>
<code>public VTextAlignment VerticalAlignment</code>
<p>The vertical aligment of the text. Bottom by default.</p>
<br>
<h3>Methods</h3>
<hr>
<code>public override void Draw()</code>
<p>Draws the text on the screen.</p>
<br>`,
`<h1><code>public class Collider</code></h1>
                <hr>
                <p>Box colliders that can be attached to elements. This class also has static methods to check if colliders are colliding</p>
                <h3>Constructors</h3>
                <hr>
                <code>public Collider(double relativeXStart, double relativeXEnd, double relativeYStart, double relativeYEnd, Element element)</code>
                <p>Creates a new collider.</p>
                <p>Parameters:</p>
                <ul>
                    <li><code>relativeXStart</code>: Value to be set as <code>RelativeXStart</code></li>
                    <li><code>relativeXEnd</code>: Value to be set as <code>RelativeXEnd</code></li>
                    <li><code>relativeYStart</code>: Value to be set as <code>RelativeYStart</code></li>
                    <li><code>relativeYEnd</code>: Value to be set as <code>RelativeYEnd</code></li>
                    <li><code>element</code>: Value to be set as <code>ParentElement</code></li>
                </ul>
                <br>
                <h3>Properties</h3>
                <hr>
                <code>public double RelativeXStart{get; set;}</code>
                <p>Gets or sets the start of the collider on the X axis in game units relative to the parent element's X position.</p>
                <br>
                <code>public double RelativeXEnd{get; set;}</code>
                <p>Gets or sets the end of the collider on the X axis in game units relative to the parent element's X position.</p>
                <br>
                <code>public double RelativeYStart{get;}</code>
                <p>Gets the start of the collider on the Y axis in game units relative to the parent element's Y position.</p>
                <br>
                <code>public double RelativeYEnd{get; set;}</code>
                <p>Gets or sets the end of the collider on the Y axis in game units relative to the parent element's Y position.</p>
                <br>
                <code>public Element ParentElement{get; set;}</code>
                <p>Gets or sets the parent element of the collider.</p>
                <br>
                <h3>Methods</h3>
                <code>static public bool IsColliding(CollidableElement element, CollidableElement element2)</code>
                <p>Checks if two collidable elements are colliding.</p>
                <p>Parameters:</p>
                <ul>
                    <li><code>element</code>: The first element.</li>
                    <li><code>element2</code>: The second element.</li>
                </ul>
                <p>Returns: <code>true</code> if the elements are colliding, <code>false</code> if not.</p>
                <br>
                <code>static public bool IsColliding(CollidableElement element, Collider collider)</code>
                <p>Checks if a collidable element is colliding with a collider.</p>
                <p>Parameters:</p>
                <ul>
                    <li><code>element</code>: The collidable element.</li>
                    <li><code>collider</code>: The collider.</li>
                </ul>
                <p>Returns: <code>true</code> if the element and the collider are colliding, <code>false</code> if not.</p>
                <br>
                <code>static public bool IsColliding(Collider collider, Collider collider2)</code>
                <p>Checks if two colliders are colliding.</p>
                <p>Parameters:</p>
                <ul>
                    <li><code>collider</code>: The first collider.</li>
                    <li><code>collider2</code>: The second collider.</li>
                </ul>
                <p>Returns: <code>true</code> if the colliders are colliding, <code>false</code> if not.</p>
                <br>
                <code>static public bool IsPointInside(CollidableElement element, double pointX, double pointY)</code>
                <p>Checks if a point is inside a collidable element.</p>
                <p>Parameters:</p>
                <ul>
                    <li><code>element</code>: The element.</li>
                    <li><code>pointX</code>: The X position of the point in game units</li>
                    <li><code>pointY</code>: The Y position of the point in game units.</li>
                </ul>
                <p>Returns: <code>true</code> if the point is inside the element, <code>false</code> if not.</p>
                <code>static public bool IsPointInside(Collider collider, double pointX, double pointY)</code>
                <p>Checks if a point is inside a collider.</p>
                <p>Parameters:</p>
                <ul>
                    <li><code>collider</code>: The collider.</li>
                    <li><code>pointX</code>: The X position of the point in game units</li>
                    <li><code>pointY</code>: The Y position of the point in game units.</li>
                </ul>
                <p>Returns: <code>true</code> if the point is inside the collider, <code>false</code> if not.</p>
                <br>`,
`<h1><code>public static class Camera</code></h1>
<hr>                
<p>The game camera.</p>
                <h3>Fields</h3>
                <hr>
                <code>public static double PosX</code>
                <p>The X position of the camera in game units.</p>
                <br>
                <code>public static double PosY</code>
                <p>The Y position of the camera in game units.</p>
                <br>`,
`<h1><code>public class Tilemap : Element</code></h1>
                <hr>
                <p>Represents a tile map element.</p>
                <h3>Constructors</h3>
                <hr>
                <code>public Tilemap()</code>
                <p>Creates an instance of the tilemap class.</p>
                <br>
                <h3>Fields</h3>
                <hr>
                <code>public List&lt;List&lt;int&gt;&gt; Map</code>
                <p>Represents the tile map where each value corresponds to an index of an item in <code>GameLogic.TileTextures</code>.</p>
                <br>
                <h3>Methods</h3>
                <hr>
                <code>public override void Draw()</code>
                <p>Draws the tile map on the screen.</p>
                <br>`,
`<h1><code>public static class Mouse</code></h1>
                <hr>
                <p>A class that represents mouse input.</p>
                <h3>Properties</h3>
                <hr>
                <code>public static double PosX {get;}</code>
                <p>Gets the X position of the mouse in game units.</p>
                <br>
                <code>public static double PosY {get;}</code>
                <p>Gets the Y position of the mouse in game units.</p>
                <br>
                <code>public static bool LeftDown {get;}</code>
                <p>Gets whether the left mouse button is down.</p>
                <br>
                <code>public static bool MiddleDown {get;}</code>
                <p>Gets whether the middle mouse button is down.</p>
                <br>
                <code>public static bool RightDown {get;}</code>
                <p>Gets whether the right mouse button is down.</p>
                <br>
                <h3>Methods</h3>
                <code>public static void GetMousePos(object? sender, MouseEventArgs e)</code>
                <p>The event handler for when the mouse is moved. This method shouldn't be called directly</p>
                <p>Parameters:</p>
                <ul>
                    <li><code>sender</code>: The object that raises the event.</li>
                    <li><code>e</code>: The event arguments.</li>
                </ul>
                <br>
                <code>public static void OnMouseDown(object? sender, MouseEventArgs e)</code>
                <p>The event handler for when a mouse button is clicked. This method shouldn't be called directly</p>
                <p>Parameters:</p>
                <ul>
                    <li><code>sender</code>: The object that raises the event.</li>
                    <li><code>e</code>: The event arguments.</li>
                </ul>
                <br>
                <code>public static void OnMouseUp(object? sender, MouseEventArgs e)</code>
                <p>The event handler for when a mouse button is released. This method shouldn't be called directly</p>
                <p>Parameters:</p>
                <ul>
                    <li><code>sender</code>: The object that raises the event.</li>
                    <li><code>e</code>: The event arguments.</li>
                </ul>
                <br>`,
`<h1><code>public static class KeyHandler</code></h1>
                <hr>
                <p>A class that represents keyboard input.</p>
                <h3>Properties</h3>
                <code>public static Dictionary&lt;string, bool&gt; KeysDown {get};</code>
                <p>Gets a hash map that contains all the keys and whether each one of them is pressed or not.</p>
                <br>
                <h3>Methods</h3>
                <hr>
                <code>public static void KeyDown(object? sender, KeyEventArgs e)</code>
                <p>The event handler for when a key is pressed. This method shouldn't be called directly</p>
                <p>ParametersL</p>
                <ul>
                    <li><code>sender</code>: The object that raises the event.</li>
                    <li><code>e</code>: The event arguments.</li>
                </ul>
                <br>
                <code>public static void KeyUp(object? sender, KeyEventArgs e)</code>
                <p>The event handler for when a key is released. This method shouldn't be called directly</p>
                <p>Parameters:</p>
                <ul>
                    <li><code>sender</code>: The object that raises the event.</li>
                    <li><code>e</code>: The event arguments.</li>
                </ul>
                <br>`,
`<h1><code>public class STexture</code></h1>
                <hr>
                <p>Class that represents a texture.</p>
                <h3>Constructors</h3>
                <hr>
                <code>public STexture(string texturePath, STextureOrigin origin)</code>
                <p>Creates an instance of the STexture class.</p>
                <p>Parameters:</p>
                <ul>
                    <li><code>texturePath</code>: The file path to the image or the name of the embedded resource.</li>
                    <li><code>origin</code>: The origin of the image.</li>
                </ul>
                <br>
                <code>public STexture(int width, int height)</code>
                <p>Creates an instance of the STexture class with an empty image.</p>
                <p>Parameters:</p>
                <ul>
                    <li><code>width</code>: The width of the image.</li>
                    <li><code>height</code>: The height of the image.</li>
                </ul>
                <br>
                <h3>Properties</h3>
                <hr>
                <code>public Image Image {get;}</code>
                <p>Gets the source image of the texture.</p>
                <br>`,
`<h1><code>public enum STextureOrigin</code></h1>
                <hr>
                <p>Represents the origin of an STexture.</p>
                <h3>Fields</h3>
                <hr>
                <code>FilePath</code>
                <p>Represents an image loaded from a file.</p>
                <br>
                <code>EmbeddedImage</code>
                <p>Represents an image loaded as an embedded resource.</p>
                <br>`];