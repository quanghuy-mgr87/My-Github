package JavaPractice.JavaOOPBasic.Point3D;

import java.util.Scanner;

public class Point3D {
    private double X;
    private double Y;
    private double Z;

    public double getX() {
        return X;
    }

    public void setX(double x) {
        X = x;
    }

    public double getY() {
        return Y;
    }

    public void setY(double y) {
        Y = y;
    }

    public double getZ() {
        return Z;
    }

    public void setZ(double z) {
        Z = z;
    }

    public Point3D(double x, double y, double z) {
        X = x;
        Y = y;
        Z = z;
    }

    public Point3D() {
        Scanner sc = new Scanner(System.in);
        
    }
}
