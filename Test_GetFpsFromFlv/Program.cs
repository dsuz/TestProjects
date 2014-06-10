using System;
using DirectShowLib;        // directshow.net library
using DirectShowLib.DES;    // directshow.net library

/*
 * memo
 * 
 * directshow.net library
 * http://directshownet.sourceforge.net/
 * 
 * Getting length of video
 * http://stackoverflow.com/questions/6215185/getting-length-of-video
 */

namespace Test_GetFpsFromFlv
{
    class Program
    {
        static void Main(string[] args)
        {
            string strFilePath = args[0];   // full file path

            var mediaDet = (IMediaDet) new MediaDet();

            try
            {
                // get object
                DsError.ThrowExceptionForHR(mediaDet.put_Filename(strFilePath));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(e.ToString());
                return;
            }

            // find the video stream in the file
            int index;
            var type = Guid.Empty;
            for (index = 0; index < 1000 && type != MediaType.Video; index++)
            {
                mediaDet.put_CurrentStream(index);
                mediaDet.get_StreamType(out type);
            }

            // get and show fps
            double frameRate;
            mediaDet.get_FrameRate(out frameRate);
            Console.WriteLine("Frame Rate: " + frameRate.ToString());

            Console.WriteLine("Hit Enter...");
            string a = Console.ReadLine();
        }
    }
}