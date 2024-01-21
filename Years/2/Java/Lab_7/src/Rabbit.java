import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.geom.AffineTransform;
import java.awt.image.AffineTransformOp;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.Random;

public class Rabbit implements Runnable {

    BufferedImage imageToLeft;
    BufferedImage imageToRight;
    JLabel rabbit;
    JPanel panel;
    Random random;

    int speed = 50;
    int timeDirection = 3;
    int directionAngle; //angle where are going the rabbit in range [0, 360]
    int width = 70;
    int height = 70;

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

    public void setTimeDirection(int _timeDirection) {

        if (_timeDirection > 0)
            timeDirection = _timeDirection;
    }


    public Rabbit(JPanel _panel, Random _random, int _speed, int _width, int _height, int _timeDirection) {

        panel = _panel;
        random = _random;
        if (_speed > 0)
            speed = _speed;
        if (_width > 0)
            width = _width;
        if (_height > 0)
            height = _height;
        if (_timeDirection > 0)
            timeDirection = _timeDirection;

        try {
            imageToLeft = ImageIO.read(new File("rabbit.png"));
        } catch (IOException ex) {
            imageToLeft = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
        }

        try {
            imageToRight = ImageIO.read(new File("rabbit.png"));
        } catch (IOException ex) {
            imageToRight = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
        }
        AffineTransform tx = AffineTransform.getScaleInstance(-1, 1);
        tx.translate(-imageToRight.getWidth(null), 0);
        AffineTransformOp op = new AffineTransformOp(tx, AffineTransformOp.TYPE_NEAREST_NEIGHBOR);
        imageToRight = op.filter(imageToRight, null);

        rabbit = new JLabel();
        rabbit.setSize(width, height);
        rabbit.setVisible(true);
        panel.add(rabbit);

        int temp = random.nextInt(361);
        if (temp >= 90 && temp < 270) {
            rabbit.setIcon(new ImageIcon(imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).getScaledInstance(width, height, imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).SCALE_DEFAULT)));
            directionAngle = temp;
        } else {
            rabbit.setIcon(new ImageIcon(imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).getScaledInstance(width, height, imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).SCALE_DEFAULT)));
            directionAngle = temp;
        }
    }


    class ChangeDirectionOfRabbit implements Runnable {

        public ChangeDirectionOfRabbit() {}

        public void run() {

            while (true) {
                try {
                    Thread.sleep(1000 * timeDirection);
                } catch (Exception ex) {
                }

                directionAngle = random.nextInt(361);

                if (directionAngle >= 90 && directionAngle < 270)
                    rabbit.setIcon(new ImageIcon(imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).getScaledInstance(width, height, imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).SCALE_DEFAULT)));
                else
                    rabbit.setIcon(new ImageIcon(imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).getScaledInstance(width, height, imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).SCALE_DEFAULT)));
            }
        }
    }


    public void run() {

        int x = random.nextInt(Math.abs( panel.getWidth() - width + 1));
        int y = random.nextInt(Math.abs( panel.getHeight() - height - 50));
        rabbit.setLocation(x, y);

        Thread changeDirectionOfRabbit = new Thread(new ChangeDirectionOfRabbit());
        changeDirectionOfRabbit.start();

        while(true) {

            double futureX = x + speed, futureY = y;
            double tempX = ( (futureX - x) * Math.cos(directionAngle/180.0*Math.PI) ) - ( (futureY - y) * Math.sin(directionAngle/180.0*Math.PI) ) + x;
            double tempY = ( (futureX - x) * Math.sin(directionAngle/180.0*Math.PI) ) + ( (futureY - y) * Math.cos(directionAngle/180.0*Math.PI) ) + y;
            futureX = (int) tempX;
            futureY = (int) tempY;

            while (futureX < 0 || futureX > panel.getWidth() - width || futureY < 0 || futureY > panel.getHeight() - height) {


                if (directionAngle < 90) { //going to right bottom

                    if (futureX > panel.getWidth() - width && futureY > panel.getHeight() - height) { //out of width and out of height

                        int tempX1 = (int) ((panel.getHeight() - y) * (futureX - x) / (double) (futureY - y) + x);

                        if (tempX1 == panel.getWidth() - width) {
                            directionAngle += 180;
                            directionAngle %= 360;
                        } else if (tempX1 < panel.getWidth() - width) {
                            directionAngle = 360 - directionAngle;
                            directionAngle %= 360;
                        } else {
                            rabbit.setIcon(new ImageIcon(imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).getScaledInstance(width, height, imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).SCALE_DEFAULT)));
                            directionAngle = 180 - directionAngle;
                            directionAngle %= 360;
                        }

                    } else if (futureY > panel.getHeight() - height) {
                        directionAngle = 360 - directionAngle;
                        directionAngle %= 360;
                    } else {
                        rabbit.setIcon(new ImageIcon(imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).getScaledInstance(width, height, imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).SCALE_DEFAULT)));
                        directionAngle = 180 - directionAngle;
                        directionAngle %= 360;
                    }

                } else if (directionAngle >= 90 && directionAngle < 180) {

                    if (futureX < 0 && futureY > panel.getHeight() - height) { //out of width and out of height

                        int tempX1 = (int) ((panel.getHeight() - y) * (futureX - x) / (double) (futureY - y) + x);

                        if (tempX1 == 0) {
                            directionAngle += 180;
                            directionAngle %= 360;
                        } else if (tempX1 > 0) {
                            directionAngle += (180 - directionAngle) * 2;
                            directionAngle %= 360;
                        } else {
                            rabbit.setIcon(new ImageIcon(imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).getScaledInstance(width, height, imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).SCALE_DEFAULT)));
                            directionAngle -= (directionAngle - 90) * 2;
                            directionAngle %= 360;
                        }

                    } else if (futureY > panel.getHeight() - height) {
                        directionAngle += (180 - directionAngle) * 2;
                        directionAngle %= 360;
                    } else {
                        rabbit.setIcon(new ImageIcon(imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).getScaledInstance(width, height, imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).SCALE_DEFAULT)));
                        directionAngle -= (directionAngle - 90) * 2;
                        directionAngle %= 360;
                    }

                } else if (directionAngle >= 180 && directionAngle < 270) {

                    if (futureX < 0 && futureY < 0) { //out of width and out of height

                        int tempX1 = (int) ((panel.getHeight() - y) * (futureX - x) / (double) (futureY - y) + x);

                        if (tempX1 == 0) {
                            directionAngle += 180;
                            directionAngle %= 360;
                        } else if (tempX1 > 0) {
                            directionAngle -= (directionAngle - 180) * 2;
                            directionAngle %= 360;
                        } else {
                            rabbit.setIcon(new ImageIcon(imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).getScaledInstance(width, height, imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).SCALE_DEFAULT)));
                            directionAngle += (270 - directionAngle) * 2;
                            directionAngle %= 360;
                        }

                    } else if (futureY < 0) {
                        directionAngle -= (directionAngle - 180) * 2;
                        directionAngle %= 360;
                    } else {
                        rabbit.setIcon(new ImageIcon(imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).getScaledInstance(width, height, imageToRight.getSubimage(0, 0, imageToRight.getWidth(), imageToRight.getHeight()).SCALE_DEFAULT)));
                        directionAngle += (270 - directionAngle) * 2;
                        directionAngle %= 360;
                    }

                } else {

                    if (futureX > panel.getWidth() - width && futureY < 0) { //out of width and out of height

                        int tempX1 = (int) ((panel.getHeight() - y) * (futureX - x) / (double) (futureY - y) + x);

                        if (tempX1 == panel.getWidth() - width) {
                            directionAngle += 180;
                            directionAngle %= 360;
                        } else if (tempX1 < panel.getWidth() - width) {
                            directionAngle += (360 - directionAngle) * 2;
                            directionAngle %= 360;
                        } else {
                            rabbit.setIcon(new ImageIcon(imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).getScaledInstance(width, height, imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).SCALE_DEFAULT)));
                            directionAngle -= (directionAngle - 270) * 2;
                            directionAngle %= 360;
                        }

                    } else if (futureY < 0) {
                        directionAngle += (360 - directionAngle) * 2;
                        directionAngle %= 360;
                    } else {
                        rabbit.setIcon(new ImageIcon(imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).getScaledInstance(width, height, imageToLeft.getSubimage(0, 0, imageToLeft.getWidth(), imageToLeft.getHeight()).SCALE_DEFAULT)));
                        directionAngle -= (directionAngle - 270) * 2;
                        directionAngle %= 360;
                    }

                }

                futureX = x + speed;
                futureY = y;
                tempX = ( (futureX - x) * Math.cos(directionAngle/180.0*Math.PI) ) - ( (futureY - y) * Math.sin(directionAngle/180.0*Math.PI) ) + x;
                tempY = ( (futureX - x) * Math.sin(directionAngle/180.0*Math.PI) ) + ( (futureY - y) * Math.cos(directionAngle/180.0*Math.PI) ) + y;
                futureX = (int) tempX;
                futureY = (int) tempY;
            }

            x = (int) futureX;
            y = (int) futureY;

            rabbit.setLocation(x, y);

            try {
                Thread.sleep(1000);
            } catch (Exception ex) {}
        }
    }
}

/*class ChangeDirectionOfRabbit implements Runnable {

    Rabbit rabbit;
    Random random;

    public ChangeDirectionOfRabbit(Rabbit _rabbit, Random _random) {

        rabbit = _rabbit;
        random = _random;

    }

    public void run() {

        while (true) {
            try {
                Thread.sleep(1000 * rabbit.timeDirection);
            } catch (Exception ex) {
            }

            rabbit.directionAngle = random.nextInt(361);

            if (rabbit.directionAngle >= 90 && rabbit.directionAngle < 270)
                rabbit.rabbit.setIcon(new ImageIcon(rabbit.imageToLeft.getSubimage(0, 0, rabbit.imageToLeft.getWidth(), rabbit.imageToLeft.getHeight()).getScaledInstance(rabbit.width, rabbit.height, rabbit.imageToLeft.getSubimage(0, 0, rabbit.imageToLeft.getWidth(), rabbit.imageToLeft.getHeight()).SCALE_DEFAULT)));
            else
                rabbit.rabbit.setIcon(new ImageIcon(rabbit.imageToRight.getSubimage(0, 0, rabbit.imageToRight.getWidth(), rabbit.imageToRight.getHeight()).getScaledInstance(rabbit.width, rabbit.height, rabbit.imageToRight.getSubimage(0, 0, rabbit.imageToRight.getWidth(), rabbit.imageToRight.getHeight()).SCALE_DEFAULT)));
        }
    }
}*/