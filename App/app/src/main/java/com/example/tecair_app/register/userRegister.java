package com.example.tecair_app.register;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.example.tecair_app.db.comonClient;
import com.example.tecair_app.MainActivity;
import com.example.tecair_app.R;
import com.example.tecair_app.db.dataBaseHelper;

public class userRegister extends AppCompatActivity{
    TextView Password, cedula;
    Button register;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_register);
        Password = findViewById(R.id.Password);
        cedula = findViewById(R.id.cedula);
    }

    public void onClickBack(View view) {
        Intent intent = new Intent(this, registerAdmin.class);
        startActivity(intent);
    }

    public void onClickRegister(View view) {
        dataBaseHelper DBhelper = new dataBaseHelper(userRegister.this);
        String pword =  Password.getText().toString();
        String ssn = cedula.getText().toString();
          if(pword.isEmpty()){
            Password.setError("Este campo no puede estar vacío");
            return;
        }  if(ssn.isEmpty()){
            cedula.setError("Este campo no puede estar vacío");
            return;
        }
        comonClient client = new comonClient(Integer.valueOf(ssn), pword);
        DBhelper.addOneRegular(client);
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }
}