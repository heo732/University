using System;
using GlmNet;
using SharpGL;
using SharpGL.Shaders;
using SharpGL.VertexBuffers;
using SharpGL.SceneGraph.Assets;


namespace WpfSharpGL
{
    /// <summary>
    /// Represents the Scene for this sample.
    /// </summary>
    /// <remarks>
    /// This code is based on work from the OpenGL 4.x Swiftless tutorials, please see:
    /// http://www.swiftless.com/opengl4tuts.html
    /// </remarks>
    public class Scene
    {
        // Coefficients of transformations
        public float coefScale = 2.0f;
        public float coefRotateAngle = 0.0f;

        mat4[] translateMatrixes = new mat4[1];

        Random random = new Random();

        Texture texture = new Texture();

        //  The projection, view and model matrices.
        mat4 projectionMatrix;
        mat4 viewMatrix;
        mat4 modelMatrix;

        //  The vertex buffer array which contains the vertex and colour buffers.
        VertexBufferArray vertexBufferArray;
    
        //  The shader program for our vertex and fragment shader.
        private ShaderProgram shaderProgram;

        /// <summary>
        /// Initialises the scene.
        /// </summary>
        /// <param name="gl">The OpenGL instance.</param>
        /// <param name="width">The width of the screen.</param>
        /// <param name="height">The height of the screen.</param>
        public void Initialise(OpenGL gl, float width, float height)
        {
            gl.Enable(OpenGL.GL_DEPTH_TEST);

            // Texture
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            texture.Create(gl, "eye.jpg");

            //  Set a blue clear colour.
            gl.ClearColor(0.4f, 0.6f, 0.9f, 1.0f);

            //  Create the shader program.
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile("Shaders.Shader.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile("Shaders.Shader.frag");
            shaderProgram = new ShaderProgram();
            shaderProgram.Create(gl, vertexShaderSource, fragmentShaderSource, null);
            shaderProgram.BindAttributeLocation(gl, 0, "in_Position");
            shaderProgram.BindAttributeLocation(gl, 1, "in_Color");
            shaderProgram.BindAttributeLocation(gl, 2, "in_Texture");
            shaderProgram.AssertValid(gl);

            //  Create a perspective projection matrix.
            //const float rads = (60.0f / 360.0f) * (float)Math.PI * 2.0f;
            //projectionMatrix = glm.perspective(rads, width / height, 0.1f, 100.0f);
            projectionMatrix = glm.perspective(glm.radians(45.0f), width / height, 0.1f, 100.0f);

            //  Create a view matrix to move us back a bit.
            viewMatrix = glm.translate(new mat4(1.0f), new vec3(0.0f, 0.0f, -5.0f));

            //  Create a model matrix to make the model a little bigger.
            modelMatrix = glm.scale(new mat4(1.0f), new vec3(2.5f));

            //  Now create the geometry for the square.
            CreateVertices(gl);

            // Create translate matrixes for pyramids
            for (int i = 0; i < translateMatrixes.Length; i++)
            {
                translateMatrixes[i] = GetRandomTranslateMatrix();
            }
        }

        /// <summary>
        /// Draws the scene.
        /// </summary>
        /// <param name="gl">The OpenGL instance.</param>
        public void Draw(OpenGL gl)
        {
            //  Clear the scene.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);



            //  Bind the shader, set the matrices.
            shaderProgram.Bind(gl);

            

            //  Bind the out vertex array.
            vertexBufferArray.Bind(gl);

            // Bind texture
            texture.Bind(gl);

            for (int i = 0; i < translateMatrixes.Length; i++)
            {
                UpdateTransformations(i);

                shaderProgram.SetUniformMatrix4(gl, "projectionMatrix", projectionMatrix.to_array());
                shaderProgram.SetUniformMatrix4(gl, "viewMatrix", viewMatrix.to_array());
                shaderProgram.SetUniformMatrix4(gl, "modelMatrix", modelMatrix.to_array());

                //  Draw the pyramid.
                gl.DrawArrays(OpenGL.GL_TRIANGLES, 0, 3 * 6);
            }

           


            //  Unbind our vertex array and shader.
            vertexBufferArray.Unbind(gl);
            shaderProgram.Unbind(gl);
        }
        
        /// <summary>
        /// Creates the geometry for the square, also creating the vertex buffer array.
        /// </summary>
        /// <param name="gl">The OpenGL instance.</param>
        private void CreateVertices(OpenGL gl)
        {
            var vertices = new float[54];
            var colors = new float[54];
            var textures = new float[36];

            // front
            vertices[0] = -0.5f; vertices[1] = -0.5f; vertices[2] = 0.5f; // Bottom left corner              
            textures[0] = 0.0f; textures[1] = 1.0f; // Bottom left corner  
            vertices[3] = 0.0f; vertices[4] = 0.5f; vertices[5] = 0.0f; // Top corner              
            textures[2] = 0.54f; textures[3] = 0.0f; // Top corner
            vertices[6] = 0.5f; vertices[7] = -0.5f; vertices[8] = 0.5f; // Bottom right corner              
            textures[4] = 1.0f; textures[5] = 1.0f; // Bottom right corner

            // back
            vertices[9] = -0.5f; vertices[10] = -0.5f; vertices[11] = -0.5f; // Bottom left corner              
            textures[6] = 0.0f; textures[7] = 1.0f; // Bottom left corner  
            vertices[12] = 0.0f; vertices[13] = 0.5f; vertices[14] = 0.0f; // Top corner              
            textures[8] = 0.54f; textures[9] = 0.0f; // Top corner
            vertices[15] = 0.5f; vertices[16] = -0.5f; vertices[17] = -0.5f; // Bottom right corner              
            textures[10] = 1.0f; textures[11] = 1.0f; // Bottom right corner

            // left
            vertices[18] = -0.5f; vertices[19] = -0.5f; vertices[20] = -0.5f; // Bottom left corner              
            textures[12] = 0.0f; textures[13] = 1.0f; // Bottom left corner  
            vertices[21] = 0.0f; vertices[22] = 0.5f; vertices[23] = 0.0f; // Top corner              
            textures[14] = 0.54f; textures[15] = 0.0f; // Top corner
            vertices[24] = -0.5f; vertices[25] = -0.5f; vertices[26] = 0.5f; // Bottom right corner              
            textures[16] = 1.0f; textures[17] = 1.0f; // Bottom right corner

            // right
            vertices[27] = 0.5f; vertices[28] = -0.5f; vertices[29] = 0.5f; // Bottom left corner              
            textures[18] = 0.0f; textures[19] = 1.0f; // Bottom left corner  
            vertices[30] = 0.0f; vertices[31] = 0.5f; vertices[32] = 0.0f; // Top corner              
            textures[20] = 0.54f; textures[21] = 0.0f; // Top corner
            vertices[33] = 0.5f; vertices[34] = -0.5f; vertices[35] = -0.5f; // Bottom right corner              
            textures[22] = 1.0f; textures[23] = 1.0f; // Bottom right corner

            // bottom_1
            vertices[36] = -0.5f; vertices[37] = -0.5f; vertices[38] = -0.5f; // Bottom left corner              
            textures[24] = 0.54f; textures[25] = 0.0f; // Bottom left corner  
            vertices[39] = -0.5f; vertices[40] = -0.5f; vertices[41] = 0.5f; // Top corner              
            textures[26] = 1.0f; textures[27] = 1.0f; // Top corner
            vertices[42] = 0.5f; vertices[43] = -0.5f; vertices[44] = -0.5f; // Bottom right corner              
            textures[28] = 0.0f; textures[29] = 1.0f; // Bottom right corner

            // bottom_2
            vertices[45] = -0.5f; vertices[46] = -0.5f; vertices[47] = 0.5f; // Top left corner              
            textures[30] = 0.0f; textures[31] = 1.0f; // Top left corner            
            vertices[48] = 0.5f; vertices[49] = -0.5f; vertices[50] = 0.5f; // Top right corner              
            textures[32] = 0.54f; textures[33] = 0.0f; // Top right corner
            vertices[51] = 0.5f; vertices[52] = -0.5f; vertices[53] = -0.5f; // Bottom corner              
            textures[34] = 1.0f; textures[35] = 1.0f; // Bottom corner

            //  Create the vertex array object.
            vertexBufferArray = new VertexBufferArray();
            vertexBufferArray.Create(gl);
            vertexBufferArray.Bind(gl);

            //  Create a vertex buffer for the vertex data.
            var vertexDataBuffer = new VertexBuffer();
            vertexDataBuffer.Create(gl);
            vertexDataBuffer.Bind(gl);
            vertexDataBuffer.SetData(gl, 0, vertices, false, 3);

            //  Now do the same for the colour data.
            //var colourDataBuffer = new VertexBuffer();
            //colourDataBuffer.Create(gl);
            //colourDataBuffer.Bind(gl);
            //colourDataBuffer.SetData(gl, 1, colors, false, 3);

            //  Now do the same for the texture data.
            var textureDataBuffer = new VertexBuffer();
            textureDataBuffer.Create(gl);
            textureDataBuffer.Bind(gl);
            textureDataBuffer.SetData(gl, 2, textures, false, 2);

            //  Unbind the vertex array, we've finished specifying data for it.
            vertexBufferArray.Unbind(gl);
        }

        private void UpdateTransformations(int indexOfPyramid)
        {
            var scaleMatrix = glm.scale(new mat4(1.0f), new vec3(coefScale));
            var rotateMatrix = glm.rotate(new mat4(1.0f), coefRotateAngle, new vec3(0.0f, 1.0f, 0.0f));
            rotateMatrix = glm.rotate(rotateMatrix, 0.5f, new vec3(1.0f, 0.0f, 0.0f));
            modelMatrix = translateMatrixes[indexOfPyramid] * rotateMatrix * scaleMatrix;
        }

        private mat4 GetRandomTranslateMatrix()
        {
            var translateMatrix = glm.translate(new mat4(1.0f), new vec3((float)random.NextDouble() * 2.0f - 1.0f, (float)random.NextDouble() * 2.0f - 1.0f, (float)random.NextDouble() * 2.0f - 1.0f));
            return translateMatrix;
        }
    }
}
