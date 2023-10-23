package com.example.tecair_app.flights;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.example.tecair_app.MainActivity;
import com.example.tecair_app.R;
import com.example.tecair_app.db.basicClient;
import com.example.tecair_app.db.dataBaseHelper;

public class basicRegister extends AppCompatActivity {
    TextView user, Lname1, Lname2, Correo, Phone, cedula;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_basic_register);
        user = findViewById(R.id.user);
        Lname1 = findViewById(R.id.Lname1);
        Lname2 = findViewById(R.id.Lname2);
        Correo = findViewById(R.id.Correo);
        Phone = findViewById(R.id.Phone);
        cedula = findViewById(R.id.cedula);
    }

    public void onClickBack(View view) {
        Intent intent = new Intent(this, viewFlights.class);
        startActivity(intent);
    }

    public void onClickContinue(View view) {
        dataBaseHelper DBhelper = new dataBaseHelper(basicRegister.this);
        String name = user.getText().toString();
        String lName1 = Lname1.getText().toString();
        String lName2 = Lname2.getText().toString();
        String email = Correo.getText().toString();
        String cel = Phone.getText().toString();
        String ssn = cedula.getText().toString();

        if(cel.isEmpty()){
            Phone.setError("Este campo no puede estar vacío");
            return;
        }  if(ssn.isEmpty()){
            cedula.setError("Este campo no puede estar vacío");
            return;
        }
        if(email.isEmpty()){
            Correo.setError("Este campo no puede estar vacío");
            return;
        } if(lName1.isEmpty()){
            Lname1.setError("Este campo no puede estar vacío");
            return;
        }
        if(lName2.isEmpty()){
            Lname2.setError("Este campo no puede estar vacío");
            return;
        } if(name.isEmpty()){
            user.setError("Este campo no puede estar vacío");
            return;
        }

        basicClient client = new basicClient(name,lName1,lName2,email,Integer.valueOf(cel),Integer.valueOf(ssn));
        if(DBhelper.exist(client)){
            Toast.makeText(basicRegister.this, "La cedula ya esta registrada", Toast.LENGTH_SHORT);
            Intent intent = new Intent(this, getPayment.class);
            startActivity(intent);
        }
        DBhelper.addOneClient(client);
        Intent intent = new Intent(this, getPayment.class);
        startActivity(intent);
    }
}