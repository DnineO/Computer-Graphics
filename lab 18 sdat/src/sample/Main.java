package sample;

import javafx.animation.RotateTransition;
import javafx.application.Application;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Group;
import javafx.scene.Parent;
import javafx.scene.PerspectiveCamera;
import javafx.scene.Scene;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.control.CheckBox;
import javafx.scene.image.Image;
import javafx.scene.paint.Color;
import javafx.scene.paint.ImagePattern;
import javafx.scene.paint.Material;
import javafx.scene.paint.PhongMaterial;
import javafx.scene.shape.*;
import javafx.scene.transform.Rotate;
import javafx.stage.Stage;
import javafx.util.Duration;

import java.io.File;
import java.util.ArrayList;
import java.util.Timer;
import java.util.TimerTask;
import java.util.zip.CheckedInputStream;

public class Main extends Application {

    public Timer timer = new Timer();
    private  CheckBox checkBoxX= new CheckBox();
    private  CheckBox checkBoxY= new CheckBox();
    private  CheckBox checkBoxZ= new CheckBox();
    @Override
    public void start(Stage primaryStage) throws Exception{


        Cylinder box = createCube();

        //String imageBG = getClass().getResource("obamium.png").toExternalForm();
        Image diffuseMap = new Image(Main.class.getResource("gold.jpg").toExternalForm());
        PhongMaterial mat = new PhongMaterial();
        mat.setDiffuseMap(diffuseMap);
        box.setMaterial(mat);
        Group root = new Group();
        root.getChildren().add(box);

        //MeshView meshView = createCube();

        // .setFill(new ImagePattern(new Image(imageBG)));
        //root.getChildren().add(meshView);
        checkBoxX.setText("Вращение по оси Y");
        checkBoxX.setLayoutX(200);
        checkBoxX.setLayoutY(10);
        checkBoxY.setText("Вращение по оси X");
        checkBoxY.setLayoutX(10);
        checkBoxY.setLayoutY(10);
        checkBoxZ.setText("Вращение по оси Z");
        checkBoxZ.setLayoutX(400);
        checkBoxZ.setLayoutY(10);
        root.getChildren().addAll(checkBoxX,checkBoxY,checkBoxZ);
        PerspectiveCamera camera = new PerspectiveCamera();
        Scene scene = new Scene(root,750,650);

        scene.setCamera(camera);
        //Parent root = FXMLLoader.load(getClass().getResource("sample.fxml"));
        primaryStage.setTitle("Texture");
        primaryStage.setResizable(false);
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    Cylinder createCube()
    {
        Cylinder box = new Cylinder(); //Box; Shpere; Cylinder; MeshView;
        box.setRadius(250.0);
        box.setHeight(3.0);
        box.setTranslateX(300);
        box.setTranslateY(300);
        box.setTranslateZ(0);
        PhongMaterial mat = new PhongMaterial();
        mat.setSpecularColor(Color.LAWNGREEN);
        mat.setDiffuseColor(Color.LAWNGREEN);
        // MeshView pyramid = new MeshView(box);
          /*  pyramid.setDrawMode(DrawMode.FILL);

            pyramid.setMaterial(mat);
            pyramid.setTranslateX(200);
            pyramid.setTranslateY(100);
            pyramid.setTranslateZ(200);*/


        box.setMaterial(mat);
        Rotate xrotation =  new Rotate(10,Rotate.X_AXIS);
        Rotate yrotation =  new Rotate(1,Rotate.Y_AXIS);
        Rotate zrotation =  new Rotate(1,Rotate.Z_AXIS);
        timer = new Timer();
        timer.scheduleAtFixedRate(new TimerTask() {
            @Override
            public void run() {
                if(checkBoxX.isSelected())
                {
                    box.getTransforms().add(xrotation);
                }
                if(checkBoxY.isSelected())
                {
                    box.getTransforms().add(yrotation);
                }
                if(checkBoxZ.isSelected())
                {
                    box.getTransforms().add(zrotation);
                }
            }
        }, 0, 20);
        return box;
    }





    public static void main(String[] args) {
        launch(args);
    }
}
