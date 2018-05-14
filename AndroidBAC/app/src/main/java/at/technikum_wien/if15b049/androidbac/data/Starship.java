package at.technikum_wien.if15b049.androidbac.data;

/**
 * Created by Sebastian on 28.04.2018.
 */

public class Starship {

    private String name;
    private String model;
    private String manufacturer;
    private double length;

    public Starship(String name, String model, String manufacturer, double length){
        this.name = name;
        this.model = model;
        this.manufacturer = manufacturer;
        this.length = length;
    }

    public String GetName() {return name;}
    public void SetName(String name ) {this.name = name;}

    public String GetModel() {return model;}
    public void SetModel(String model) {this.model = model;}

    public String GetManufacturer() {return manufacturer;}
    public void SetManufacturer(String manufacturer) {this.manufacturer = manufacturer;}

    public double GetLength() {return length;}
    public void SetLength(double length) {this.length = length;}
}
