export class EnviromentUtils {

    public static LoginUrl = EnviromentUtils.ReadValue('LOGIN_URL')

    public static ApiBaseUrl = EnviromentUtils.ReadValue('API_BASE_URL')

    public static DefaultImageUrl = EnviromentUtils.ReadValue('DEFAULT_IMAGE_URL')

    public static ImageRootDirectoryUrl = EnviromentUtils.ReadValue('IMAGE_ROOT_DIRECTORY_URL')

    private static ReadValue(keyName: string) {
        return process.env[`REACT_APP_${keyName}`] || ''
    }
}