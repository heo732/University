#pragma once

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing;

namespace CppCLR
{
	public ref class Figure
	{
		public: String^ text;
		public: System::Drawing::Color color;
		protected: Point^ position = gcnew Point(0, 0);

		public: virtual void DrawToPictureBox(PictureBox^ pictureBox) = 0;
		public: virtual void MoveTo(int x, int y) = 0;
	};

	public ref class Circle : Figure
	{
		public: double radius;

		public: Circle(double _radius, Point^ _position, System::Drawing::Color _color, String^ _text)
		{
			radius = _radius;
			if (_position != nullptr)
			{
				position->X = _position->X;
				position->Y = _position->Y;
			}
			color = _color;
			text = _text;
		}

		public: void MoveTo(int x, int y) override
		{
			position->X = x;
			position->Y = y;
		}

		public: void DrawToPictureBox(PictureBox^ pictureBox) override
		{
			Bitmap^ bmp;
			if (pictureBox->Image != nullptr)
				bmp = gcnew Bitmap(pictureBox->Image);
			else
				bmp = gcnew Bitmap(pictureBox->Width, pictureBox->Height);
			Graphics^ graphics = Graphics::FromImage(bmp);
			graphics->DrawEllipse(gcnew Pen(color, 2), (int)(position->X - radius), (int)(position->Y - radius), (int)(radius * 2), (int)(radius * 2));
			graphics->DrawString(text, gcnew Font(FontFamily::GenericSansSerif, 8), Brushes::Black, position->X - text->Length / 2 * 6, position->Y - 4);
			pictureBox->Image = bmp;
		}
	};

	public ref class Square : Figure
	{
		public: double side;

		public: Square(double _side, Point^ _position, Color _color, String^ _text)
		{
			side = _side;
			if (_position != nullptr)
			{
				position->X = _position->X;
				position->Y = _position->Y;
			}
			color = _color;
			text = _text;
		}

		public: void MoveTo(int x, int y) override
		{
			position->X = x;
			position->Y = y;
		}

		public: void DrawToPictureBox(PictureBox^ pictureBox) override
		{
			Bitmap^ bmp;
			if (pictureBox->Image != nullptr)
				bmp = gcnew Bitmap(pictureBox->Image);
			else
				bmp = gcnew Bitmap(pictureBox->Width, pictureBox->Height);
			Graphics^ graphics = Graphics::FromImage(bmp);
			graphics->DrawRectangle(gcnew Pen(color, 2), (int)(position->X - side / 2), (int)(position->Y - side / 2), (int)(side), (int)(side));
			graphics->DrawString(text, gcnew Font(FontFamily::GenericSansSerif, 8), Brushes::Black, position->X - text->Length / 2 * 6, position->Y - 4);
			pictureBox->Image = bmp;
		}
	};

	public ref class EquilateralTriangle : Figure
	{
		public: double side;

		public: EquilateralTriangle(double _side, Point^ _position, Color _color, String^ _text)
		{
			side = _side;
			if (_position != nullptr)
			{
				position->X = _position->X;
				position->Y = _position->Y;
			}
			color = _color;
			text = _text;
		}

		public: void MoveTo(int x, int y) override
		{
			position->X = x;
			position->Y = y;
		}

		public: void DrawToPictureBox(PictureBox^ pictureBox) override
		{
			Bitmap^ bmp;
			if (pictureBox->Image != nullptr)
				bmp = gcnew Bitmap(pictureBox->Image);
			else
				bmp = gcnew Bitmap(pictureBox->Width, pictureBox->Height);
			Graphics^ graphics = Graphics::FromImage(bmp);
			double h = side * (Math::Sqrt(3) / 2);
			array<Point>^ points = gcnew array<Point>(3);
			points[0] = Point(position->X, (int)(position->Y - h / 2));
			points[1] = Point((int)(position->X + side / 2), (int)(position->Y + h / 2));
			points[2] = Point((int)(position->X - side / 2), (int)(position->Y + h / 2));
			graphics->DrawPolygon( gcnew Pen(color, 2), points);
			graphics->DrawString(text, gcnew Font(FontFamily::GenericSansSerif, 8), Brushes::Black, position->X - text->Length / 2 * 6, position->Y - 4);
			pictureBox->Image = bmp;
		}
	};

	public ref class HexagonalStar : Figure
	{
		public: double side;

		public: HexagonalStar(double _side, Point^ _position, Color _color, String^ _text)
		{
			side = _side;
			if (_position != nullptr)
			{
				position->X = _position->X;
				position->Y = _position->Y;
			}
			color = _color;
			text = _text;
		}

		public: void MoveTo(int x, int y) override
		{
			position->X = x;
			position->Y = y;
		}

		public: void DrawToPictureBox(PictureBox^ pictureBox) override
		{
			Bitmap^ bmp;
			if (pictureBox->Image != nullptr)
				bmp = gcnew Bitmap(pictureBox->Image);
			else
				bmp = gcnew Bitmap(pictureBox->Width, pictureBox->Height);
			Graphics^ graphics = Graphics::FromImage(bmp);
			double h = side * (Math::Sqrt(3) / 2);
			array<Point>^ points = gcnew array<Point>(3);
			points[0] = Point(position->X, (int)(position->Y - h * 2));
			points[1] = Point((int)(position->X + side + side / 2), (int)(position->Y + h));
			points[2] = Point((int)(position->X - side - side / 2), (int)(position->Y + h));
			graphics->DrawPolygon(gcnew Pen(color, 2), points);
			points[0] = Point(position->X, (int)(position->Y + h * 2));
			points[1] = Point((int)(position->X + side + side / 2), (int)(position->Y - h));
			points[2] = Point((int)(position->X - side - side / 2), (int)(position->Y - h));
			graphics->DrawPolygon(gcnew Pen(color, 2), points);
			graphics->DrawString(text, gcnew Font(FontFamily::GenericSansSerif, 8), Brushes::Black, position->X - text->Length / 2 * 6, position->Y - 4);
			pictureBox->Image = bmp;
		}
	};
}