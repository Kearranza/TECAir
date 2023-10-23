package com.example.tecair_app.flights;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

import com.example.tecair_app.flights.flightAdmin;
import com.example.tecair_app.R;

public class viewFlights extends AppCompatActivity {
    String date1, date2, origin, destiny;
    TextView flight;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_flights);
        flightAdmin fa = new flightAdmin();
        date1 = fa.getFormatDate1();
        date2 = fa.getFormatDate2();
        destiny = fa.getDestiny();
        origin = fa.getOrigin();
        flight = findViewById(R.id.flight);
        flight.setText(origin + destiny + " del " + date1 + " al "+ date2);
    }

    public void onClickPay(View view) {
        Intent intent = new Intent(this, basicRegister.class);
        startActivity(intent);
    }

    public void onClickBack(View view) {
        Intent intent = new Intent(this, flightAdmin.class);
        startActivity(intent);
    }
}