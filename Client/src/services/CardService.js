import axios from 'axios'

export default class CardService {
    static create(data, onSuccess, onError) {
        axios.post(`http://localhost:3024/api/card`, data)
            .then(response => onSuccess(response))
            .catch(err => onError(err))
    }
}