import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.geom.AffineTransform;
import java.awt.image.AffineTransformOp;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.Random;

public class Albino implements Runnable {

    BufferedImage imageToLeft;
    BufferedImage imageToRight;
    JLabel albino;
    JPanel panel;
    Random random;

    int speed = 50;
    boolean direction = true; //false - toRight, true - toLeft
    int width = 60;
    int height = 40;

    public void setSpeed(int _speed) {

        if (_speed > 0)
            speed = _speed;
    }

    public void setSize(int _width, int _height) {

        if (_height > 0 && _width > 0) {

            width = _width;
            height = _height;
        }
    }

    public Albino(JPanel _panel, Random _random, int _speed, int _width, int _height) {

        panel = _panel;
        random = _random;
        if (_speed > 0)
            speed = _speed;
        if (_width > 0)
            width = _width;
        if (_height > 0)
            height = _height;

        try {
            imageToLeft = ImageIO.read(new File("albino.png"));
        } catch (IOException ex) {
            imageToLeft = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
        }

        try {
            imageToRight = ImageIO.read(new File("albino.png"));
        } catch (IOException ex) {
            imageToRight = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
        }
        AffineTransform tx = AffineTransform.getScaleInstance(-1, 1);
        tx.translate(-imageToRight.getWidth(null), 0);
        AffineTransformOp op = new AffineTransformOp(tx, AffineTransformOp.TYPE_NEAREST_NEIGHBOR);
        imageToRight = op.filter(imageToRight, null);

        albino = new JLabel();
        albino.setSize(width, height);
        albino.setVisible(true);
        panel.add(albino);

        if (random.nextInt(2) == 0) {
            albino.setIcon(new ImageIcon(imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).getScaledInstance(width, height, imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).SCALE_DEFAULT)));
            direction = true;
        } else {
            albino.setIcon(new ImageIcon(imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).getScaledInstance(width, height, imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).SCALE_DEFAULT)));
            direction = false;
        }
    }

    public void run() {

        int x = random.nextInt(Math.abs( panel.getWidth() - width + 1));
        albino.setLocation(x, random.nextInt(Math.abs( panel.getHeight() - height - 50 )));
        while(true) {

            if (direction == false && x + speed > panel.getWidth() - width) { //toRight

                direction = !direction;
                albino.setIcon(new ImageIcon(imageToLeft.getSubimage(0,0,imageToLeft.getWidth(),imageToLeft.getHeight()).getScaledInstance(width, height, imageToLeft.getSubimage(0,0,imageToLeft.getWidth(),imageToLeft.getHeight()).SCALE_DEFAULT)));
            }

            if (direction == true && x - speed < 0) { //toLeft

                direction = !direction;
                albino.setIcon(new ImageIcon(imageToRight.getSubimage(0,0,imageToRight.getWidth(),imageToRight.getHeight()).getScaledInstance(width, height, imageToRight.getSubimage(0,0,imageToRight.getWidth(),imageToRight.getHeight()).SCALE_DEFAULT)));
            }

            if (direction) {

                x -= speed;
            } else {

                x += speed;
            }

            albino.setLocation(x, albino.getY());

            try {
                Thread.sleep(1000);
            } catch (Exception ex) {}
        }
    }
}