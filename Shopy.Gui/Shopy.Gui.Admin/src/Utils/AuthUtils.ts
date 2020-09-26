export class AuthUtils {
    public static GetToken() {
        return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZGFtbTkzMS5OaXMiLCJqdGkiOiJmOGVhNzZkNi04YmQ1LTQ5MzctODY2NC03ZDZjOWRlYTM3N2IiLCJuYmYiOjE2MDExMTUwOTMsImV4cCI6MTYwMTEyMjI5MywiaXNzIjoibG9jYWxob3N0IiwiYXVkIjoibG9jYWxob3N0In0.-Bu4OUVyqKmxB3084tKDM-NOo0iUvoCXOE86TO-QPpo"
    }

    public static IsAuthenticated() {
        return AuthUtils.GetToken() !== ''
    }
}