using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpGL.SceneGraph;
using SharpGL;
using SharpGL.Shaders;
using System.Threading;

namespace WpfSharpGL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Scene scene = new Scene();
        private Thread threadExecuteScale;
        private Thread threadExecuteTranslateY;
        private Thread threadExecuteRotate;
        private bool ExecuteTransformationsSwitch = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="SharpGL.SceneGraph.OpenGLEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLDraw(object sender, OpenGLEventArgs args)
        {
            //  Draw the scene.
            scene.Draw(openGLControl.OpenGL);            
        }

        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="SharpGL.SceneGraph.OpenGLEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            //  Initialise the scene.
            scene.Initialise(openGLControl.OpenGL, (float)Width, (float)Height);

            threadExecuteScale = new Thread(() =>
            {
                float directScale = 1.0f;
                while (ExecuteTransformationsSwitch)
                {
                    if (scene.coefScale > 1.0)
                        directScale = -1.0f;
                    if (scene.coefScale < 0.5)
                        directScale = 1.0f;
                    scene.coefScale += 0.005f * directScale;
                    Thread.Sleep(10);
                }
            });
            threadExecuteScale.Start();

            threadExecuteRotate = new Thread(() =>
            {
                while (ExecuteTransformationsSwitch)
                {
                    scene.coefRotateAngle += 0.01f;
                    Thread.Sleep(10);
                }
            });
            threadExecuteRotate.Start();            
        }

        /// <summary>
        /// Handles the Resized event of the openGLControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="SharpGL.SceneGraph.OpenGLEventArgs"/> instance containing the event data.</param>
        private void openGLControl_Resized(object sender, OpenGLEventArgs args)
        {
            //  TODO: Set the projection matrix here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            //  Use the 'look at' helper function to position and aim the camera.
            gl.LookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ExecuteTransformationsSwitch = false;
        }
    }
}
