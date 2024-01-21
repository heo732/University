import java.io.*;

class FileReadFacade {
    String readFile(String fileName) throws IOException {
        BufferedReader reader = new BufferedReader(new FileReader(fileName));
        StringBuilder stringBuilder = new StringBuilder();
        int j = 0;
        while ((j = reader.read()) != -1) {
            stringBuilder.append((char)j);
        }
        return stringBuilder.toString();
    }
}