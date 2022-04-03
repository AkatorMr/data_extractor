# Data Extractor
Extractor de información de archivos jpg

En realidad ya no extrae info de los archivos.
Ahora solo modifica los comentarios de los archivos jpg,


### Funcionamiento

Inicio

    foo
    │   DataExtractor.exe
    │   File1.jpg
    │   Nota.txt
    │
    └───bar
        │   File2.jpg
        │   Medicion.txt
        │
        └───foo2
                File3.jpg
                File4.jpg
                Medicion.txt
                Nombre.txt
                Nota.txt
### Final

    foo
    │   DataExtractor.exe
    │   File1.jpg
    │   Nota.txt
    │	File1.jpg_original
    │
    └───bar
        │   File2.jpg
        │   File2.jpg_original
        │   Medicion.txt
        │
        └───foo2
                File3.jpg
                File4.jpg
    	        File3.jpg_original
                File4.jpg_original
                Medicion.txt
                Nombre.txt
                Nota.txt

Resultado:
Los archivos jpg tienen un comentario con la ubicación relativa al ejecutable y el contenido de los archivos de texto en el siguiente orden:

Nombre.txt
Medicion.txt
Nota.txt si este archivo no se encuentra, escribe el texto "Sin observaciones"

    Ej: File4.jpg

        bar\foo2\n
        <Contenido de Nombre.txt>\n
        Med:<Contenido de Medicion.txt>\n
        <Contenido de Nota.txt>\n
