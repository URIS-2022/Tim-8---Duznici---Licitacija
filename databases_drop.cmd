@echo off

echo Dropping databases for all API projects...

for /d %%d in (*API*) do (
  echo Dropping database for project: %%d
  pushd "%%d"
  dotnet ef database drop --force
  popd
)

echo All databases updated.
