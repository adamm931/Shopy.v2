import { BaseUrl, Compose } from './Urls'
import axios from 'axios'

class Client {

    private baseUrl: string;

    constructor(baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    async Post<TBody, TRespone = any>(relativeUrl: string, body: TBody): Promise<TRespone> {

        const url = Compose(this.baseUrl, relativeUrl);

        var response: TRespone = await axios
            .post(url, body)
            .then(response => response.data)
            .catch(error => console.error(`Error occured with request: '${url}'`, error));

        return response;
    }

}

export default new Client(BaseUrl)