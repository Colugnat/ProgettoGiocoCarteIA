using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoCarteIA.Model
{
    public class Camera
    {
        public WebEye.Controls.Wpf.WebCameraId CameraId { get; set; }
        public string Name { get { return CameraId.Name; } }
    }
}
