using System.Drawing;

DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory);
string fileNumber = string.Empty,
    filePath = string.Empty;
int fileName,
    filex,
    filey;

FileInfo[] files = di.GetFiles("dragitem*.png", SearchOption.TopDirectoryOnly);

foreach (FileInfo file in files)
{
    fileNumber = GetNumbers(file.Name);
    filex = 0;
    filey = 0;

    for (int i = 0; i < 36; i++)
    {
        Console.WriteLine(((Int32.Parse(fileNumber) - 1) * 36) + 500 + i);
        fileName = (((int.Parse(fileNumber) - 1) * 36) + 500) + i;
        filePath = "itemimages/" + fileName + ".png";

        Bitmap source = new(file.Name);

        if (filex > 200)
        {
            filex = 0;
        }
        if (filey > 200)
        {
            filey = 0;
            filex += 40;
        }

        Rectangle section = new Rectangle(filex, filey, 40, 40);

        Bitmap CroppedImage = (Bitmap)CropImage(source, section);

        CroppedImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

        filey += 40;
    }
}

Console.ReadLine();

Image CropImage(Image img, Rectangle cropArea)
{
    Bitmap bmpImage = new(img);
    return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
}

string GetNumbers(string input)
{
    return new string(input.Where(c => char.IsDigit(c)).ToArray());
}
