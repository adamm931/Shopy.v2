import axios from 'axios'

class Client {

    async Post<TRespone, TBody = any>(url: string, body: TBody): Promise<TRespone> {

        var response: TRespone = await axios
            .post(url, body)
            .then(response => response.data)
            .catch(error => console.error(`Error occured with request: '${url}'`, error));

        return response;
    }

}

export default new Client()