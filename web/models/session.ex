defmodule PhoenixLogger.Session do
  use PhoenixLogger.Web, :model

  schema "sessions" do
    field :token, :string
    belongs_to :user, PhoenixLogger.User

    timestamps()
  end

  @required_fields ~w(user_id)
  @optional_fields ~w()

  def changeset(model, params \\ :empty) do
    model
    |> cast(params, @required_fields, @optional_fields)
  end

  def registration_changeset(model, params \\ :empty) do
    model
    |> changeset(params)
    |> put_change(:token, SecureRandom.urlsafe_base64())
  end
end
