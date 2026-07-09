using System;
using System.Drawing;
using System.Drawing.Imaging;

public class ImageSlicer {
    public static void Process(string sourcePath, string outDir) {
        string[] names = new string[] {
            "t_farmer", "t_market", "t_energy", "t_builder", "t_auto", "t_terra",
            "t_rich", "t_guardian", "t_traditional", "t_donation", "t_caveman", "t_review",
            "t_romantic", "t_impatient", "t_squirrel", "t_frozen", "t_vvip", "t_destroy"
        };
        
        using (Bitmap src = new Bitmap(sourcePath)) {
            int rows = 3;
            int cols = 6;
            int w = src.Width / cols;
            int h = src.Height / rows;
            Color bgColor = src.GetPixel(0, 0);
            
            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    int idx = r * cols + c;
                    if (idx >= names.Length) break;
                    
                    using (Bitmap piece = new Bitmap(w, h)) {
                        for (int y = 0; y < h; y++) {
                            for (int x = 0; x < w; x++) {
                                Color p = src.GetPixel(c * w + x, r * h + y);
                                int diff = Math.Abs(p.R - bgColor.R) + Math.Abs(p.G - bgColor.G) + Math.Abs(p.B - bgColor.B);
                                if (diff < 30) {
                                    piece.SetPixel(x, y, Color.Transparent);
                                } else {
                                    piece.SetPixel(x, y, p);
                                }
                            }
                        }
                        piece.Save(outDir + "\\" + names[idx] + ".png", ImageFormat.Png);
                    }
                }
            }
        }
    }
}
