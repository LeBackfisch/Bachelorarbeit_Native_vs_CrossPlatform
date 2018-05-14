package at.technikum_wien.if15b049.androidbac.data;

import android.support.v4.content.AsyncTaskLoader;
import android.content.Context;
import android.icu.math.BigDecimal;
import android.os.Build;
import android.support.annotation.RequiresApi;

/**
 * Created by Sebastian on 30.04.2018.
 */

@RequiresApi(api = Build.VERSION_CODES.N)
public class PrimeLoader extends AsyncTaskLoader<Prime> {

    private Prime prime;
    private static final BigDecimal FOUR = BigDecimal.valueOf(4);
    private static final int roundingMode = BigDecimal.ROUND_HALF_EVEN;

    public PrimeLoader(Context context) {super(context);}

    @RequiresApi(api = Build.VERSION_CODES.N)
    @Override
    public Prime loadInBackground() {
        long result = findPrimeNumber(100000);
        prime = new Prime(result);
        return prime;
    }

    @Override
    protected void onStartLoading(){
        super.onStartLoading();
        forceLoad();
    }

    private static long findPrimeNumber(int n){
        int count = 0;
        long a = 2;
        while(count < n){
            long b = 2;
            int prime = 1;
            while(b*b <= a){
                if(a % b == 0){
                    prime = 0;
                    break;
                }
                b++;
            }
            if(prime > 0){
                count++;
            }
            a++;
        }
        return (--a);
    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    private static BigDecimal computePi(int digits) {
        int scale = digits + 5;
        BigDecimal arctan1_5 = arctan(5, scale);
        BigDecimal arctan1_239 = arctan(239, scale);
        BigDecimal pi = arctan1_5.multiply(FOUR).subtract(arctan1_239).multiply(FOUR);
        return pi.setScale(digits, BigDecimal.ROUND_HALF_UP);
    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    private static BigDecimal arctan(int inverseX, int scale) {
        BigDecimal result, numer, term;
        BigDecimal invX = BigDecimal.valueOf(inverseX);
        BigDecimal invX2 = BigDecimal.valueOf(inverseX * inverseX);
        numer = BigDecimal.ONE.divide(invX, scale, roundingMode);
        result = numer;
        int i = 1;
        do {
            numer = numer.divide(invX2, scale, roundingMode);
            int denom = 2 * i + 1;
            term = numer.divide(BigDecimal.valueOf(denom), scale, roundingMode);
            if ((i % 2) != 0) {
                result = result.subtract(term);
            } else {
                result = result.add(term);
            }
            i++;
        } while (term.compareTo(BigDecimal.ZERO) != 0);
        return result;
    }
}
