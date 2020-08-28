import React, { ChangeEvent } from 'react'

export class BaseComponent<S = {}, P = {}> extends React.Component<S, P> {

    onChange = (event: ChangeEvent<HTMLInputElement>, propName: any) => {
        event.preventDefault()

        this.setState({
            ...this.state,
            [propName]: event.target.value
        })
    }
}