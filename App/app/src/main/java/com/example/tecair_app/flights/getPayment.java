package com.example.tecair_app.flights;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.example.tecair_app.R;

public class getPayment extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_get_payment);
    }

    public void onClickBack(View view) {
        Intent intent = new Intent(this, viewFlights.class);
        startActivity(intent);
    }
}