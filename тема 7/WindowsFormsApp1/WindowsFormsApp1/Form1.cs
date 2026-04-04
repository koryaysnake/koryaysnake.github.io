using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Figure> _figures = new List<Figure>();
        Figure _selected = null;

        Point _start;
        bool _drawing = false;

        string _mode = "rect";
        Figure _clipboard = null;

        float _currentWidth = 2;
        Color _currentColor = Color.Black;

        bool _resizeHole = false;


        public Form1()
        {
            InitializeComponent();

            canvasPanel.Paint += Canvas_Paint;
            canvasPanel.MouseDown += Canvas_MouseDown;
            canvasPanel.MouseUp += Canvas_MouseUp;
            canvasPanel.MouseClick += Canvas_MouseClick;

            KeyPreview = true;
            KeyDown += Form_KeyDown;
        }

        
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var f in _figures)
                f.Draw(e.Graphics);

            if (_selected != null)
                SelectionFrame.Draw(e.Graphics, _selected.Bounds);
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selected is RectangleWithHoleFigure hole)
            {
                if (hole.OnMarker(e.Location))
                {
                    _resizeHole = true;
                    return;
                }
            }

            _start = e.Location;
            _drawing = true;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            _resizeHole = false;

            if (!_drawing) return;

            Rectangle rect = new Rectangle(
                Math.Min(_start.X, e.X),
                Math.Min(_start.Y, e.Y),
                Math.Abs(_start.X - e.X),
                Math.Abs(_start.Y - e.Y));

            Figure f = null;

            if (_mode == "rect") f = new RectangleFigure(rect);
            if (_mode == "square") f = new SquareFigure(rect);
            if (_mode == "hole") f = new RectangleWithHoleFigure(rect);

            if (f != null)
            {
                f.Stroke.Width = _currentWidth;
                f.Stroke.Color = _currentColor;
                _figures.Add(f);
            }

            _drawing = false;
            canvasPanel.Invalidate();
        }


        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            _selected = null;

            foreach (var f in _figures)
                if (f.Contains(e.Location))
                    _selected = f;

            canvasPanel.Invalidate();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_resizeHole && _selected is RectangleWithHoleFigure hole)
            {
                hole.ChangeRadius(e.Location);
                canvasPanel.Invalidate();
            }
        }


        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (_selected == null) return;

            int step = e.Shift ? 1 : 5;

            if (e.KeyCode == Keys.Left) _selected.Move(-step, 0);
            if (e.KeyCode == Keys.Right) _selected.Move(step, 0);
            if (e.KeyCode == Keys.Up) _selected.Move(0, -step);
            if (e.KeyCode == Keys.Down) _selected.Move(0, step);

            canvasPanel.Invalidate();
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Black;

            if (_selected != null)
                _selected.Stroke.Color = _currentColor;

            canvasPanel.Invalidate();
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Red;

            if (_selected != null)
                _selected.Stroke.Color = _currentColor;

            canvasPanel.Invalidate();
        }


        private void btnGreen_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Green;

            if (_selected != null)
                _selected.Stroke.Color = _currentColor;

            canvasPanel.Invalidate();
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Blue;

            if (_selected != null)
                _selected.Stroke.Color = _currentColor;

            canvasPanel.Invalidate();
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Yellow;

            if (_selected != null)
                _selected.Stroke.Color = _currentColor;

            canvasPanel.Invalidate();
        }

        private void thicknessBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, что выбран элемент
            if (thicknessBox.SelectedItem == null) return;

            // Пробуем преобразовать выбранное значение
            string selectedValue = thicknessBox.SelectedItem.ToString();

            if (float.TryParse(selectedValue, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out float width))
            {
                _currentWidth = width;

                if (_selected != null)
                    _selected.Stroke.Width = _currentWidth;

                canvasPanel.Invalidate();
            }
            else
            {
                MessageBox.Show($"Некорректное значение толщины: {selectedValue}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void menuRect_Click(object sender, EventArgs e)
        {
            _mode = "rect";
        }

        private void menuSquare_Click(object sender, EventArgs e)
        {
            _mode = "square";
        }

        private void menuHole_Click(object sender, EventArgs e)
        {
            _mode = "hole";
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (_selected != null)
            {
                _figures.Remove(_selected);
                _selected = null;
                canvasPanel.Invalidate();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, _selected);
                ms.Position = 0;
                _clipboard = (Figure)bf.Deserialize(ms);
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (_clipboard == null) return;

            Figure newFigure;

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, _clipboard);
                ms.Position = 0;
                newFigure = (Figure)bf.Deserialize(ms);
            }

            newFigure.Move(10, 10);

            _figures.Add(newFigure);
            canvasPanel.Invalidate();
        }


        private void menuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() != DialogResult.OK) return;

            using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, _figures);
            }
        }

        private void menuLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() != DialogResult.OK) return;

            using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                _figures = (List<Figure>)bf.Deserialize(fs);
            }

            canvasPanel.Invalidate();
        }
    }

}
