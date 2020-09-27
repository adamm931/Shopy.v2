import { RouteComponentProps } from 'react-router-dom';
import { history } from '../State/ShopyStore';

export class UriUtils {

    public static RedirectToPath(path: string) {
        history.push(path);
    }

    public static RedirectToUrl(url: string) {
        window.location.replace(url);
    }

    public static ReadId = (route: RouteComponentProps): string => {
        let entry = Object.entries(route.match.params).find(e => e[0] === 'id')

        if (entry === undefined) {
            return '';
        }

        return entry[1] as string
    }
}