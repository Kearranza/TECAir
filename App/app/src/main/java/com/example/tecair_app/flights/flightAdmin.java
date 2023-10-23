package com.example.tecair_app.flights;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.util.Pair;
import androidx.fragment.app.DialogFragment;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.example.tecair_app.MainActivity;
import com.example.tecair_app.R;
import com.google.android.material.datepicker.MaterialDatePicker;
import com.google.android.material.datepicker.MaterialPickerOnPositiveButtonClickListener;
import com.google.android.material.navigation.NavigationBarView;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Locale;
import java.util.Objects;
import java.util.TimeZone;

public class flightAdmin extends AppCompatActivity implements AdapterView.OnItemSelectedListener{
    TextView date1, date2;
    Button start, end;
    String origin, destiny;

    String formatDate1, formatDate2 = "";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_flight_admin);

        Spinner spinner = findViewById(R.id.spiner);
        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(this, R.array.destinos, android.R.layout.simple_spinner_item);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinner.setAdapter(adapter);
        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
               setOrigin((String) adapterView.getItemAtPosition(i));
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });

        Spinner spinner2 = findViewById(R.id.spiner2);
        ArrayAdapter<CharSequence> arr = ArrayAdapter.createFromResource(this, R.array.destinos, android.R.layout.simple_spinner_item);
        arr.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinner2.setAdapter(arr);
        spinner2.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                setDestiny((String) adapterView.getItemAtPosition(i));
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });

        date1 = findViewById(R.id.date1);
        date2 = findViewById(R.id.date2);
        start = findViewById(R.id.start);
        end = findViewById(R.id.end);

        MaterialDatePicker.Builder builder = MaterialDatePicker.Builder.datePicker();
        builder.setSelection(Calendar.getInstance().getTimeInMillis());
        final MaterialDatePicker<Long> datePicker = builder.build();
        final MaterialDatePicker<Long> datePicker2 = builder.build();
        start.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                datePicker.show(getSupportFragmentManager(), "Date Picker");
                datePicker.addOnPositiveButtonClickListener(new MaterialPickerOnPositiveButtonClickListener<Long>() {
                    @Override
                    public void onPositiveButtonClick(Long selection) {
                        Calendar calendar = Calendar.getInstance(TimeZone.getTimeZone("UTC"));
                        calendar.setTimeInMillis(selection);
                        SimpleDateFormat format = new SimpleDateFormat("yyyy MM dd");
                        setFormatDate1(format.format(calendar.getTime()));
                        Toast.makeText(flightAdmin.this, formatDate1, Toast.LENGTH_SHORT).show();
                        date1.setText(formatDate1);
                    }
                });
            }
        });
        end.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                datePicker2.show(getSupportFragmentManager(), "Date Picker 2");
                datePicker2.addOnPositiveButtonClickListener(new MaterialPickerOnPositiveButtonClickListener<Long>() {
                    @Override
                    public void onPositiveButtonClick(Long selection) {
                        Calendar calendar = Calendar.getInstance(TimeZone.getTimeZone("UTC"));
                        calendar.setTimeInMillis(selection);
                        SimpleDateFormat format = new SimpleDateFormat("yyyy MM dd");
                        setFormatDate2(format.format(calendar.getTime()));
                        Toast.makeText(flightAdmin.this, formatDate2, Toast.LENGTH_SHORT).show();
                        date2.setText(formatDate2);
                    }
                });
            }
        });

    }


    public void onClickBack(View view) {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }



    public void onClickViewFlights(View view) {
        if((!Objects.equals(origin,destiny)) &&(!Objects.equals(formatDate2, formatDate1)) && (!Objects.equals(formatDate1, "")) && (!Objects.equals(formatDate2, ""))){
            Intent intent = new Intent(this, viewFlights.class);
            startActivity(intent);
        }
        Toast.makeText(flightAdmin.this, "Debe escoger fechas validas", Toast.LENGTH_SHORT).show();
        return;
    }

    @Override
    public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {

    }

    @Override
    public void onNothingSelected(AdapterView<?> adapterView) {

    }

    public String getOrigin() {
        return origin;
    }

    public String getDestiny() {
        return destiny;
    }

    public String getFormatDate1() {
        return formatDate1;
    }

    public String getFormatDate2() {
        return formatDate2;
    }

    public void setOrigin(String origin) {
        this.origin = origin;
    }

    public void setDestiny(String destiny) {
        this.destiny = destiny;
    }

    public void setFormatDate1(String formatDate1) {
        this.formatDate1 = formatDate1;
    }

    public void setFormatDate2(String formatDate2) {
        this.formatDate2 = formatDate2;
    }
}