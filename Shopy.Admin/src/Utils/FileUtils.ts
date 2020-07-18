export class FileUtils {

    public static ReadAsBase64String = (file: File): string | ArrayBuffer | null => {

        let base64: string | ArrayBuffer | null = '';

        let reader = new FileReader()
        reader.readAsDataURL(file)
        reader.onload = () => base64 = reader.result
        reader.onerror = (error) => console.log('Error: ', error)

        return base64
    }

}

