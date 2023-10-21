package com.example.tecair_app;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.example.tecair_app.flights.flightAdmin;
import com.example.tecair_app.login.loginAdmin;
import com.example.tecair_app.promos.promosAdmin;
import com.example.tecair_app.register.registerAdmin;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void onClickFlights(View view) {
        Intent intent = new Intent(this, flightAdmin.class);
        startActivity(intent);
    }

    public void onClickPromo(View view) {
        Intent intent = new Intent(this, promosAdmin.class);
        startActivity(intent);
    }

    public void onClickRegister(View view) {
        Intent intent = new Intent(this, registerAdmin.class);
        startActivity(intent);
    }

    public void onClickLogin(View view) {
        Intent intent = new Intent(this, loginAdmin.class);
        startActivity(intent);
    }
}