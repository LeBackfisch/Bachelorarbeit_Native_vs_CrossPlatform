package at.technikum_wien.if15b049.androidbac.data;

/**
 * Created by Sebastian on 30.04.2018.
 */

public class Prime {
    private double value;

    public Prime(double value){
        this.value = value;
    }

    public double GetPi() {return value;}
    public void SetPi(double value ) {this.value = value;}
}
