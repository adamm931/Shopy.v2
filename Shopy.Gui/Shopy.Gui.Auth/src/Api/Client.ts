import { BaseUrl, Compose } from './Urls'
import axios from 'axios'

class Client {

    private baseUrl: string;

    constructor(baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    async Post<TBody>(relativeUrl: string, body: TBody): Promise<any> {

        const url = Compose(this.baseUrl, relativeUrl);

        return await axios
            .post(url, body)
            .then(response => response.data)
            .catch(error => console.error(`Error occured with request: '${url}'`, error));
    }

}

export default new Client(BaseUrl)