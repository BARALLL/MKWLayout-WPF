## ⚠️ In progress - early development 🛠️

c# WPF desktop application using ML.NET GAN to generate racing track heightmap images

    Roadmap:
        UI:
          Overall:
            buttons, labels... should stay consistent even when the window is resized

        Menus:
        - database
            2 columns : vertical panel on the left
                                buttons: add image folder/add 1 image, remove images (works like rm image on phone (selection of every img you want to rm))
                                         add feature, remove feature            on the same line
                                        clear database: prompt are you sure

                                        add/rm img show a re-train model to include img button 
                                        add/rm feature prompt are you sure? you will have to train the model entirely again

                                list of features under buttons

                        image collection on the right

                        clicking on an image update value fields on features and show button rm image (will rm this one only)

        - Model
            create new / save / load / train model buttons on the middle left
            generated img on the left, with a add to database button underneath it
            when save or load button is clicked, open a windows explorer tab
            when add to db button clicked, prompt re-train ?

        GAN:
            modify ImageData and ImagePrediction class to be a list of feature (add/rm) and
            to allow different image size
