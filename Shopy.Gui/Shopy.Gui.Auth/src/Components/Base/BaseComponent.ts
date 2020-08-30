import React, { ChangeEvent, FormEvent } from 'react'

export class BaseComponent<Props, State> extends React.Component<Props, State> {

    protected onInputChange(event: ChangeEvent<HTMLInputElement>, propertyOfState: keyof State): void {
        event.preventDefault()

        this.setState({
            ...this.state,
            [propertyOfState]: event.target.value
        })
    }

    protected onSubmit(event: FormEvent<HTMLFormElement>, onSubmitAction: () => void) {
        event.preventDefault()
        onSubmitAction()
    }
}